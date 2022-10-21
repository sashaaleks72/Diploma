import UserModel from "./UserModel";

interface AuthModel {
    accessToken: string;
    user: UserModel;
}

export default AuthModel;
