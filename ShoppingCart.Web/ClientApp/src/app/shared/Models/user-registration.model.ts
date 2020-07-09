export class UserRegistration {
  constructor(
    public username: string,
    public password: string,
    public firstname: string,
    public lastname: string,
    public email: string,
    public mobilenumber: string,
    public address1: string,
    public address2: string,
    public address3: string,
    public confirmPassword: string
  ) { }
}
