import { CartItem } from "../store/Cart.store";

interface OrderModel {
    firstName: string;
    lastName: string;
    patronymic: string;
    email: string;
    city: string;
    department: string;
    deliveryAddress: string;
    cartItems: CartItem[];
    orderDate: string;
    orderStatus: string;
    id: string;
    totalSum: number;
}

export default OrderModel;
