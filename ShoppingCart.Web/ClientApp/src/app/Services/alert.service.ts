import { Injectable } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Observable, Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AlertService {
    private subject = new Subject<any>();
    private keepAfterRouteChange = false;

    constructor(private router: Router) {
        
    }

    getAlert(): Observable<any> {
        return this.subject.asObservable();
    }

    success(message: string) {
        this.subject.next({ type: 'success', text: message });
    }

    error(message: string) {
        this.subject.next({ type: 'error', text: message });
    }

    clear() {
        // clear by calling subject.next() without parameters
        this.subject.next();
    }
}