import { Component, forwardRef, Input, Injector, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule, FileUploadHandlerEvent } from 'primeng/fileupload';
import { ControlValueAccessor, FormsModule, NG_VALUE_ACCESSOR, ReactiveFormsModule, NgControl } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';


@Component({
  selector: 'lib-upload-file',
  imports: [CommonModule, FormsModule, ReactiveFormsModule, FileUploadModule, ButtonModule],
  templateUrl: './upload-file.component.html',
  styleUrl: './upload-file.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => UploadFileComponent),
      multi: true,
    }
  ]
})
export class UploadFileComponent implements ControlValueAccessor, OnInit{
  
  @Input() mode: 'basic' | 'advanced' = 'basic'
  @Input() chooseLabel = ''
  @Input() label = ''
  @Input() chooseIcon = "pi pi-upload"
  @Input() name = ''
  @Input() url = ''
  @Input() accept = '.png,.jpg,.jpeg,.pdf'
  @Input() maxFileSize = '1000000000'
  @Input() auto = false

  fileName = '';
  filePreview : SafeResourceUrl | string | null = null;
  isPdf = false

  onChange: any = () => undefined;
  onTouch: any = () => undefined;

  constructor(
    private sanitizer: DomSanitizer,
    private injector: Injector
  ) {}

  ngControl: NgControl | null = null;

  ngOnInit(): void {
    this.ngControl = this.injector.get(NgControl, null);
    if (this.ngControl) {
      this.ngControl.valueAccessor = this;
    }
  }

  writeValue(value: any): void {
    if(value){
      this.loadImageAsFile(value)
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouch = fn;
  }

  get isRequiredError() {
  return this.ngControl?.control?.hasError('required') && this.ngControl?.control?.touched;
}

  async loadImageAsFile(file: File): Promise<void> {
    this.onChange(file);
    this.onTouch();
    this.createImagePreview(file);

    const fullName = file.name; 
    const lastDotIndex = fullName.lastIndexOf('.');
    
    const fileName = fullName.substring(0, lastDotIndex);
    const ext = fullName.substring(lastDotIndex + 1);
    this.fileName = `${fileName}.${ext}`;
  }

  onFileSelect(event: FileUploadHandlerEvent) {
    const file = event.files?.[0];
    if(file){
      this.onChange(file); 
      this.onTouch(); 
      this.createImagePreview(file);
      this.fileName = event.files?.[0].name
    }
  }

  createImagePreview(file: File): void {
    const reader = new FileReader();

    reader.onload = (e: any) => {
      const raw = e.target.result;

      const type = file.type;

      if (type === 'application/pdf') {
        this.isPdf = true
        this.filePreview = this.sanitizer.bypassSecurityTrustResourceUrl(raw);
      } else {
        this.isPdf = false
        this.filePreview = raw;
      }
    };

    reader.readAsDataURL(file);
  }

  removeFile(): void {
    
    this.fileName = '';
    this.filePreview = '';

    this.onChange(null);  
    this.onTouch(); 

  }
}
