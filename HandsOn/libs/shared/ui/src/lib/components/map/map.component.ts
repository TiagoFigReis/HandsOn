import {
  Component,
  OnDestroy,
  AfterViewInit,
  ViewChild,
  ElementRef,
  inject,
  forwardRef,
  OnInit,
  Injector,
  Input
} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import * as L from 'leaflet';
import 'leaflet-draw';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, NgControl } from '@angular/forms';

const iconRetinaUrl = 'images/marker-icon-2x.png';
const iconUrl = 'images/marker-icon.png';
const shadowUrl = 'images/marker-shadow.png';
const iconDefault = L.icon({
  iconRetinaUrl, iconUrl, shadowUrl, iconSize: [25, 41], iconAnchor: [12, 41],
  popupAnchor: [1, -34], tooltipAnchor: [16, -28], shadowSize: [41, 41]
});
L.Marker.prototype.options.icon = iconDefault;

@Component({
  selector: 'lib-map',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => MapComponent),
      multi: true
    }
  ]
})
export class MapComponent implements AfterViewInit, OnDestroy, ControlValueAccessor, OnInit {
  @Input() id = ''
  @Input() label = ''
  @ViewChild('mapContainer') private mapContainer!: ElementRef<HTMLDivElement>;

  onChange: (value: any) => void = () => {return};
  onTouched: () => void = () => {return};

  private map!: L.Map;
  private searchMarker: L.Marker | null = null;
  private http = inject(HttpClient);
  private drawnItems!: L.FeatureGroup;
  private initialValue: any = null;

  ngControl: NgControl | null = null;

  constructor(
        private injector: Injector
      ) {}

  writeValue(value: any): void {
    this.initialValue = value;
    if (this.map && this.initialValue) {
      this.drawInitialPolygon();
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  ngAfterViewInit(): void {
    this.initMap();
  }

  ngOnInit(): void {
      this.ngControl = this.injector.get(NgControl, null);
      if (this.ngControl) {
        this.ngControl.valueAccessor = this;
      }
    }

    get errorMessage(): string | null {
    if (!this.ngControl?.invalid || !(this.ngControl.dirty || this.ngControl.touched)) {
      return null;
    }

    const errors = this.ngControl.errors;
    if (!errors) {
      return null;
    }

    const errorKey = Object.keys(errors)[0];

    const message = errorMessages[errorKey as keyof typeof errorMessages].replace(
        '{0}', this.label);

    return message
  }

  private initMap(): void {
    if (!this.mapContainer || !this.mapContainer.nativeElement) {
      return;
    }

    const streetMap = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });
    const satelliteMap = L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}', {
      attribution: 'Tiles &copy; Esri'
    });

    this.map = L.map(this.mapContainer.nativeElement, {
        center: [-14.235, -51.925],
        zoom: 4,
        layers: [satelliteMap]
    });

    const baseMaps = { "Satélite": satelliteMap, "Ruas": streetMap };
    L.control.layers(baseMaps, {}, { position: 'bottomleft' }).addTo(this.map);

    this.drawnItems = new L.FeatureGroup();
    this.map.addLayer(this.drawnItems);

    const drawControl = new L.Control.Draw({
      edit: { featureGroup: this.drawnItems },
      draw: {
        polygon: {
          shapeOptions: { color: '#ff0000' },
          allowIntersection: false,
        },
        polyline: false, circle: false, marker: false, circlemarker: false, rectangle: false
      }
    });
    this.map.addControl(drawControl);

    this.map.on(L.Draw.Event.CREATED, (event) => {
      const layer = (event as L.DrawEvents.Created).layer;
      this.drawnItems.clearLayers();
      this.drawnItems.addLayer(layer);
      const GeoJSON = layer.toGeoJSON();
      this.onChange(GeoJSON.geometry.coordinates);
      this.onTouched();
    });

    this.map.on(L.Draw.Event.EDITED, (event) => {
      const layers = (event as L.DrawEvents.Edited).layers;
      layers.eachLayer(layer => {
        const GeoJSON = (layer as L.Polygon).toGeoJSON();
        this.onChange(GeoJSON.geometry.coordinates);
        this.onTouched();
      });
    });

    this.map.on(L.Draw.Event.DELETED, () => {
      if (this.drawnItems.getLayers().length === 0) {
        this.onChange(null);
        this.onTouched();
      }
    });

    if (this.initialValue) {
      this.drawInitialPolygon();
    } else {
      this.centerOnUserLocation();
    }
  }

  private drawInitialPolygon(): void {
    if (!this.initialValue || !Array.isArray(this.initialValue) || this.initialValue.length === 0) {
      return;
    }

    if (this.drawnItems && this.map) {
      this.drawnItems.clearLayers();
      
      const geoJsonFeature = {
        "type": "Feature",
        "properties": {},
        "geometry": {
          "type": "Polygon",
          "coordinates": this.initialValue
        }
      };

      const newLayer = L.geoJSON(geoJsonFeature as any, {
        style: { color: '#ff0000' }
      });
      
      this.drawnItems.addLayer(newLayer);
      
      setTimeout(() => this.map.fitBounds(newLayer.getBounds()), 100);
    }
  }

  searchLocation(address: string): void {
    if (!address) return;
    const url = `https://nominatim.openstreetmap.org/search?q=${encodeURIComponent(address)}&format=json&limit=1`;
    this.http.get<any[]>(url).subscribe({
      next: (results) => {
        if (results && results.length > 0) {
          const result = results[0];
          const lat = parseFloat(result.lat);
          const lon = parseFloat(result.lon);
          const coords: L.LatLngExpression = [lat, lon];
          
          this.map.setView(coords, 14);

          if (this.searchMarker) {
            this.searchMarker.remove();
          }

          this.searchMarker = L.marker(coords).addTo(this.map);
        }
      },
      error: (err) => console.error('Erro na busca de localização:', err)
    });
  }

  private centerOnUserLocation(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position: GeolocationPosition) => {
          const userCoords: L.LatLngExpression = [position.coords.latitude, position.coords.longitude];
          this.map.setView(userCoords, 16);
          L.marker(userCoords).addTo(this.map).bindPopup('<b>Você está aqui!</b>');
        },
        () => console.log('Não foi possível obter a localização. Usando localização padrão.')
      );
    }
  }

  ngOnDestroy(): void {
    if (this.map) {
      this.map.off();
      this.map.remove();
    }
  }
}

const errorMessages = {
    required: '{0} é obrigatório',
}