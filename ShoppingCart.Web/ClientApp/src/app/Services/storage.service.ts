import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';

const SECRET_KEY = 'secret_key';


@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  // setSessionValue(key: string, value: any) {
  //   sessionStorage.setItem(key, this.encryptData(value))
  // }

  // getSessionValue(key: string) {
  //    this.decryptData(sessionStorage.getItem(key)) 
  // }

  // clearSession() {
  //   sessionStorage.clear()
  // }

  encryptData(data) {
    return CryptoJS.AES.encrypt(JSON.stringify(data), SECRET_KEY).toString();
  }

  decryptData(data) {
    const bytes = CryptoJS.AES.decrypt(data, SECRET_KEY);
    if (bytes.toString()) {
      return JSON.parse(bytes.toString(CryptoJS.enc.Utf8));
    }
    return data;
  }
}
