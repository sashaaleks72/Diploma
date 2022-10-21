import { observer } from "mobx-react-lite";
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import "./App.css";
import ProfileComponent from "./Auth/ProfileComponent";
import SignUpComponent from "./Auth/SignUpComponent";
import CartComponent from "./Cart/CartComponent";
import CartItemComponent from "./Cart/CartItemComponent";
import CatalogComponent from "./Catalog/CatalogComponent";
import CatalogMainComponent from "./Catalog/CatalogMainComponent";
import ProductAddComponent from "./Catalog/ProductAddComponent";
import ProductChangeComponent from "./Catalog/ProductChangeComponent";
import ProductComponent from "./Catalog/ProductComponent";
import HeaderComponent from "./Header/HeaderComponent";
import UserModel from "./models/UserModel";
import MakeAnOrderComponent from "./Order/MakeAnOrderComponent";
import OrdersComponent from "./Order/OrdersComponent";
import { Cart } from "./store/Cart.store";
import { Catalog } from "./store/Catalog.store";
import { User } from "./store/User.store";

export const cart = new Cart();
export const catalog = new Catalog();
export const user = new User();

if (localStorage.getItem("token")) {
    let userFromLocalStorage = localStorage.getItem("user");

    if (userFromLocalStorage != null) {
        user.setUser(JSON.parse(userFromLocalStorage) as UserModel);
        user.setAuth(true);
    }
}

const App = observer(() => {
    return (
        <BrowserRouter>
            <HeaderComponent />
            <div className="container">
                <Routes>
                    <Route path="/catalog" element={<CatalogMainComponent />} />
                    <Route
                        path="/catalog/teapots"
                        element={<CatalogComponent productType="Teapots" />}
                    />
                    <Route
                        path="/catalog/coffee-machines"
                        element={
                            <CatalogComponent productType="Coffee machines" />
                        }
                    />
                    <Route path="/catalog/:id" element={<ProductComponent />} />
                    <Route
                        path="/catalog/edit-product/:id"
                        element={<ProductChangeComponent />}
                    />
                    <Route
                        path="/add-product"
                        element={<ProductAddComponent />}
                    />
                    <Route
                        path="/cart"
                        element={
                            <CartComponent>
                                {cart.cartItems.map((item, index) => (
                                    <CartItemComponent
                                        key={item.id}
                                        id={item.id}
                                        price={item.price}
                                        title={item.title}
                                        imgUrl={item.imgUrl}
                                        quantity={item.quantity}
                                    />
                                ))}
                            </CartComponent>
                        }
                    />
                    {user.isAuth ? (
                        <>
                            <Route
                                path="/profile"
                                element={<ProfileComponent />}
                            />
                            <Route
                                path="/my-orders"
                                element={<OrdersComponent />}
                            />
                            <Route
                                path="/make-an-order"
                                element={<MakeAnOrderComponent />}
                            />
                        </>
                    ) : (
                        <Route path="/register" element={<SignUpComponent />} />
                    )}

                    <Route
                        path="*"
                        element={<Navigate replace to="/catalog" />}
                    />
                </Routes>
            </div>
        </BrowserRouter>
    );
});

export default App;
