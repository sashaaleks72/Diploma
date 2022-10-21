import { user } from "../App";
import CatalogItemDto from "../dtos/CatalogItemDto";
import ProductDto from "../dtos/ProductDto";
import AuthModel from "../models/AuthModel";
import ErrorModel from "../models/ErrorModel";
import OrderModel from "../models/OrderModel";
import ProfileModel from "../models/ProfileModel";
import SignInModel from "../models/SignInModel";
import SignUpModel from "../models/SignUpModel";
import UserModel from "../models/UserModel";

const apiUrl = "http://localhost:44374/api";

export const makeAnOrder = async (order: OrderModel): Promise<any> => {
    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
        body: JSON.stringify(order),
    };

    await fetch(`${apiUrl}/orders`, requestOptions);
};

export const getUserOrders = async (userId: string): Promise<OrderModel[]> => {
    const requestOptions = {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
    };

    const result: Response = await fetch(
        `${apiUrl}/orders?userId=${userId}`,
        requestOptions
    );

    const response = await result.json();

    const orders: OrderModel[] = response;

    return orders;
};

export const getCatalogItems = async (): Promise<CatalogItemDto[]> => {
    const result: Response = await fetch(`${apiUrl}/catalog-items`);
    const response = await result.json();

    const catalogItems: CatalogItemDto[] = response;

    return catalogItems;
};

export const getProducts = async (
    productType: string,
    sortParams: string = "",
    page: number = 0,
    limit: number = 0
): Promise<ProductDto[]> => {
    let [fieldForSort, howToSort]: string[] = [];

    if (sortParams != null) {
        [fieldForSort, howToSort] = sortParams.split(":");
    }

    let products: ProductDto[] = [];

    await fetch(
        `${apiUrl}/products?productType=${productType}&sort=${fieldForSort}&order=${howToSort}&page=${page}&limit=${limit}`
    ).then(async (result) => {
        if (result.status === 404) {
            return products;
        }

        products = await result.json();
    });

    return products;
};

export const getProductById = async (
    id: string | undefined
): Promise<ProductDto> => {
    const result: Response = await fetch(`${apiUrl}/products/${id}`);
    const response: ProductDto = await result.json();

    const product: ProductDto = response;

    return product;
};

export const delProductById = async (id: string | undefined): Promise<any> => {
    const requestOptions = {
        method: "DELETE",
    };

    await fetch(`${apiUrl}/products/${id}`, requestOptions);
};

export const addNewProduct = async (product: ProductDto): Promise<any> => {
    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(product),
    };

    await fetch(`${apiUrl}/products`, requestOptions);
};

export const signUp = async (
    signUpModel: SignUpModel
): Promise<AuthModel | ErrorModel> => {
    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(signUpModel),
    };

    let result: Response = await fetch(`${apiUrl}/sign-up`, requestOptions);
    let response: AuthModel | ErrorModel = await result.json();

    return response;
};

export const signIn = async (
    signInModel: SignInModel
): Promise<AuthModel | ErrorModel> => {
    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(signInModel),
    };

    let result: Response = await fetch(`${apiUrl}/sign-in`, requestOptions);
    let response: AuthModel | ErrorModel = await result.json();

    return response;
};

export const editProfile = async (
    id: string,
    profileModel: ProfileModel
): Promise<any> => {
    const requestOptions = {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
        body: JSON.stringify(profileModel),
    };

    await fetch(`${apiUrl}/users/${id}`, requestOptions);
};

export const getProfile = async (id: string): Promise<any> => {
    const requestOptions = {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
    };

    const result: Response = await fetch(
        `${apiUrl}/users/${id}`,
        requestOptions
    );
    const response: ProfileModel = await result.json();

    const profile: ProfileModel = response;

    return profile;
};

export const changeProduct = async (
    id: string | undefined,
    product: ProductDto | undefined
): Promise<any> => {
    const requestOptions = {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(product),
    };

    await fetch(`${apiUrl}/products/${id}`, requestOptions);
};

export const getDepartments = async (city: string): Promise<any> => {
    const apiKey = process.env.REACT_APP_API_NP_KEY;

    const body = {
        apiKey: apiKey,
        modelName: "Address",
        calledMethod: "getWarehouses",
        methodProperties: {
            CityName: city,
        },
    };

    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(body),
    };

    const response: Response = await fetch(
        `https://api.novaposhta.ua/v2.0/json/`,
        requestOptions
    );
    const responseJson: any = await response.json();

    const departments: string[] = responseJson.data.map(
        (value: { Description: string }) => {
            return value.Description;
        }
    );

    return departments;
};
