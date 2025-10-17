import PrimeUI from 'tailwindcss-primeui';
import { addDynamicIconSelectors } from '@iconify/tailwind';

export default {
  darkMode: 'class',
  content: [
    './src/**/*.{html,js,ts,jsx,tsx}',
    './libs/**/*.{html,js,ts,jsx,tsx}',
  ],
  theme: {
    extend: {},
  },
  safelist: [
    'icon-[fa6-solid--mound]',
  ],
  plugins: [
    PrimeUI,
    addDynamicIconSelectors(),
  ],
};
