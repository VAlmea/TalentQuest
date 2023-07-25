import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class Interceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = localStorage.getItem('token');
        if (token) {
            const cloned = req.clone({
                headers: req.headers.set("Authorization","Bearer " + token)
                .set("Content-Type", "application/json")
                .set("Access-Control-Allow-Origin", "*")
            });
            return next.handle(cloned);
        }
        else {
            return next.handle(req);
        }
    } 
}