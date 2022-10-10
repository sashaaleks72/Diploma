import CatalogItemDto from "../dtos/CatalogItemDto";
import ProductDto from "../dtos/ProductDto";
import OrderModel from "../models/OrderModel";
import ProfileModel from "../models/ProfileModel";
import SignUpModel from "../models/SignUpModel";

const apiUrl = "http://localhost:5000";

export const makeAnOrder = async (order: OrderModel): Promise<any> => {
    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(order),
    };

    await fetch(`${apiUrl}/orders`, requestOptions);
};

export const getUserOrders = async (): Promise<OrderModel[]> => {
    const result: Response = await fetch(`${apiUrl}/orders`);

    const response = await result.json();

    const orders: OrderModel[] = response;

    return orders;
};

export const getCatalogItems = async (): Promise<CatalogItemDto[]> => {
    const result: Response = await fetch(`${apiUrl}/catalogItems`);
    const response = await result.json();

    const catalogItems: CatalogItemDto[] = response;

    return catalogItems;
};

export const getProducts = async (
    productType: string,
    sortParams?: string,
    page?: number,
    limit?: number
): Promise<ProductDto[]> => {
    let [fieldForSort, howToSort]: string[] = [];

    if (sortParams != null) {
        [fieldForSort, howToSort] = sortParams.split(":");
    }

    const result: Response = await fetch(
        `${apiUrl}/products?productType=${productType}&_sort=${fieldForSort}&_order=${howToSort}&_page=${page}&_limit=${limit}`
    );
    const response = await result.json();

    const products: ProductDto[] = response;

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

export const signUp = async (signUpModel: SignUpModel): Promise<any> => {
    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(signUpModel),
    };

    //await fetch(`${apiUrl}/sign-up`, requestOptions);
    await fetch(`${apiUrl}/users`, requestOptions);
};

export const editProfile = async (
    id: string,
    profileModel: ProfileModel
): Promise<any> => {
    const requestOptions = {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(profileModel),
    };

    //await fetch(`${apiUrl}/sign-up`, requestOptions);
    await fetch(`${apiUrl}/users/${id}`, requestOptions);
};

export const getProfile = async (id: string): Promise<any> => {
    const result: Response = await fetch(`${apiUrl}/users/${id}`);
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
