import { DOCUMENT, isPlatformBrowser } from '@angular/common';
import { Inject, Injectable, PLATFORM_ID, Renderer2, RendererFactory2 } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export type Theme = 'light' | 'dark';

@Injectable({
  providedIn: 'root',
})
export class ThemeService {
  private renderer: Renderer2;
  private currentTheme: Theme = 'light'; // Iniciar com um padrão seguro

  private theme$$ = new BehaviorSubject<Theme>(this.currentTheme);
  public theme$ = this.theme$$.asObservable();

  constructor(
    private rendererFactory: RendererFactory2,
    @Inject(DOCUMENT) private document: Document,
    @Inject(PLATFORM_ID) private platformId: object // 1. Injetar o PLATFORM_ID
  ) {
    this.renderer = this.rendererFactory.createRenderer(null, null);

    // 2. Chamar a inicialização DENTRO do construtor
    // A verificação 'isPlatformBrowser' garante que 'localStorage' e 'window' existam
    if (isPlatformBrowser(this.platformId)) {
      this.initializeTheme();
    }
  }

  initializeTheme() {
    const storedTheme = localStorage.getItem('app-theme') as Theme | null;
    const systemTheme = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    const initialTheme = storedTheme || systemTheme;
    this.setTheme(initialTheme);
  }

  toggleTheme() {
    const newTheme = this.currentTheme === 'dark' ? 'light' : 'dark';
    this.setTheme(newTheme);
  }

  private setTheme(theme: Theme) {
    this.currentTheme = theme;
    localStorage.setItem('app-theme', theme);
    this.theme$$.next(theme);

    if (theme === 'dark') {
      this.renderer.addClass(this.document.documentElement, 'dark');
    } else {
      this.renderer.removeClass(this.document.documentElement, 'dark');
    }
  }
}