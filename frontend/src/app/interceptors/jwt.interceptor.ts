import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, take } from "rxjs";
import { AccountService } from "../services/account.service";
import { IUser } from "../models/user";


@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(private accountService: AccountService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let currentUser: IUser;

        this.accountService.currentUser$.pipe(take(1)).subscribe({
            next: response => currentUser = response
        });

        if(currentUser) {
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${currentUser.token}`
                }
            });
        }

        return next.handle(req);
    }
}