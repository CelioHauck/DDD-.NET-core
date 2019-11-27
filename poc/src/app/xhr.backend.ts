import { Request, XHRBackend, BrowserXhr, ResponseOptions, XSRFStrategy, Response } from '@angular/http';
import { Observable, EMPTY, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Router } from "@angular/router";

@Injectable()
export class XhrBack extends XHRBackend {

    constructor(_browserXhr: BrowserXhr, _baseResponseOptions: ResponseOptions, _xsrfStrategy: XSRFStrategy, private router: Router) {
        super(_browserXhr, _baseResponseOptions, _xsrfStrategy, );
    }

    createConnection(request: Request) {
        let xhrConnection = super.createConnection(request);
        xhrConnection.response = xhrConnection.response.pipe(catchError(err => {
            if (err.status == 401) {
                this.router.navigate(['']);
                return EMPTY;
            }
        }));
        return xhrConnection;
    }

}