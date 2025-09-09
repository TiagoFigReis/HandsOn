export interface Environment {
  production: boolean;

  // Google
  clientId: string;
  redirectUri: string;

  // JWT
  jwtToken: string;
  allowedDomains: string[];

  // API URLs
  authApiUrl: string;
  usersApiUrl: string;
  analiseApiUrl: string;
  dataAnalysisApiUrl: string;
  nutrientTablesApiUrl: string;
  fertilizerTablesApiUrl: string;
  culturesApiUrl: string;
  formulationTablesApiUrl: string;
}
