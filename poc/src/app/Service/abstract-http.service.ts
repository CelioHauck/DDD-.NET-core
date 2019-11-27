import { Http, RequestOptions, Headers } from "@angular/http";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";



export abstract class AbstractHttpService<T> {

    private apiUrl: string = environment.apiUrl;

    constructor(
        private resource: string, 
        private http: Http) {
    }

    public queryAll(): Observable<T[]> {
        return this.http.get(`${this.apiUrl}${this.resource}`, this.getCustomOptions())
            .pipe(map(response => response.json()));
    }

    public queryAllPath(path:string): Observable<T[]> {
        return this.http.get(`${this.apiUrl}${this.resource}/${path}`, this.getCustomOptions())
            .pipe(map(response => response.json()));
    }

    public get(id: number): Observable<T> {
        return this.http.get(`${this.apiUrl}${this.resource}/${id}`, this.getCustomOptions())
            .pipe(map(response => response.json()));
    }

    public post(requestBody: T): Observable<T> {
        return this.http.post(`${this.apiUrl}${this.resource}`, requestBody, this.getCustomOptions())
            .pipe(map(response => response.json()));
    }

    public postPath(requestBody: T, path:string ): Observable<T> {
        return this.http.post(`${this.apiUrl}${this.resource}/${path}`, requestBody, this.getCustomOptions())
            .pipe(map(response => response.json()));
    }

    public put(requestBody: T): Observable<T> {
        return this.http.put(`${this.apiUrl}${this.resource}/${requestBody['id']}`, requestBody, this.getCustomOptions())
            .pipe(map(response => response.json()));
    }

    public delete(requestBody: number) {
        return this.http.delete(`${this.apiUrl}${this.resource}/${requestBody}`, this.getCustomOptions())
            .pipe(map(response => response));
    }

    private buildQueryParams(params: any): string {
        let queryParams: string = '';

        for (let property in params) {
            if (queryParams === '') {
                queryParams += `${[property]}=${params[property]}`;
            } else {
                queryParams += `&${[property]}=${params[property]}`;
            }
        }

        return queryParams;
    }

    private getCustomOptions(): RequestOptions {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let authToken = localStorage.getItem('auth_token');
        if(authToken != null){
            headers.append('Authorization', `Bearer ${authToken}`)
        }
        return new RequestOptions({headers: headers});
    }
}