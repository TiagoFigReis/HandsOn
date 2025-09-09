import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationInterceptor } from './lib/interceptors/authentication/authentication.interceptor';

// config
export * from './lib/config/app-config.token';

// models
export * from './lib/models/environment.model';
export * from './lib/models/token.model';
export * from './lib/models/user.model';
export * from './lib/models/analise.model';
export * from './lib/models/nutrient-table.model';
export * from './lib/models/culture.model';
export * from './lib/models/fertilizer-table.model';
export * from './lib/models/formulation-table.model';

// services
export * from './lib/services/authentication/authentication.service';
export * from './lib/services/confirmation/confirmation.service';
export * from './lib/services/notification/notification.service';
export * from './lib/services/request/request.service';
export * from './lib/services/user/user.service';
export * from './lib/services/analise/analise.service';
export * from './lib/services/dataAnalysis/dataAnalysis.service';
export * from './lib/services/nutrient-table/nutrient-table.service';
export * from './lib/services/culture/culture.service';
export * from './lib/services/fertilizer-table/fertilizer-table.service';
export * from './lib/services/formulation-table/formulation-table.service';

// facades
export * from './lib/facades/auth.facade';
export * from './lib/facades/user.facade';
export * from './lib/facades/analise.facade';
export * from './lib/facades/dataAnalysis.facade';
export * from './lib/facades/nutrient-table.facade';
export * from './lib/facades/culture.facade';
export * from './lib/facades/fertilizer-table.facade';
export * from './lib/facades/formulation-table.facade';

// guards
export * from './lib/guards/authenticated/authenticated.guard';
export * from './lib/guards/is-admin/is-admin.guard';

// interceptors
export const interceptorsProviders = [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthenticationInterceptor,
    multi: true,
  },
];

export { BYPASS_INTERCEPTORS } from './lib/interceptors/authentication/authentication.interceptor';

// utils
export * from './lib/utils/form-validators';
export * from './lib/utils/min-max-validator';
export * from './lib/utils/min-med-max-validator';
export * from './lib/utils/descending-values-validator';

// enums
export * from './lib/enums/user-roles.enum';
export * from './lib/enums/user-status.enum';
export * from './lib/enums/nutrient-table-divisions.enum';
export * from './lib/enums/nutrient-headers.enum';

