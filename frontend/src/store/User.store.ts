import { makeAutoObservable } from "mobx";
import { signIn, signUp } from "../http/fetches";
import AuthModel from "../models/AuthModel";
import ErrorModel from "../models/ErrorModel";
import ProfileModel from "../models/ProfileModel";
import SignInModel from "../models/SignInModel";
import SignUpModel from "../models/SignUpModel";
import UserModel from "../models/UserModel";

export class User {
    isAuth: boolean = false;
    user: UserModel = {} as UserModel;

    constructor() {
        makeAutoObservable(this);
    }

    setAuth(authState: boolean) {
        this.isAuth = authState;
    }

    setUser(user: UserModel) {
        this.user = user;
    }

    editUser(changedUser: ProfileModel) {
        this.user.firstName = changedUser.firstName;
        this.user.lastName = changedUser.lastName;
        this.user.patronymic = changedUser.patronymic;
        this.user.birthday = changedUser.birthday;

        localStorage.setItem("user", JSON.stringify(this.user));
    }

    async signIn(credentials: SignInModel) {
        let response = await signIn(credentials);

        if (!(response as ErrorModel).error) {
            let authModel: AuthModel = response as AuthModel;

            let token: string = authModel.accessToken;
            let userFromResponse: UserModel = authModel.user;

            localStorage.setItem("token", token);
            localStorage.setItem("user", JSON.stringify(userFromResponse));

            this.setAuth(true);
            this.setUser(userFromResponse);
        } else {
            throw (response as ErrorModel).error;
        }
    }

    async signUp(newUser: SignUpModel) {
        let response = await signUp(newUser);

        if (!(response as ErrorModel).error) {
            let authModel: AuthModel = response as AuthModel;

            let token: string = authModel.accessToken;
            let userFromResponse: UserModel = authModel.user;

            localStorage.setItem("token", token);
            localStorage.setItem("user", JSON.stringify(userFromResponse));

            this.setAuth(true);
            this.setUser(userFromResponse);
        } else {
            throw (response as ErrorModel).error;
        }
    }

    signOut() {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
    }
}
