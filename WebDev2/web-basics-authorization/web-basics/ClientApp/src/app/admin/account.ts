export interface Account {
  id: number;
  email: string;
  password: string;
  role: AccountRole;
}

export enum AccountRole {
  Admin = 1, 
  User = 0
}
