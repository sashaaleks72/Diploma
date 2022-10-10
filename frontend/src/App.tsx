import { observer } from "mobx-react-lite";
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import "./App.css";
import ProfileComponent from "./Auth/ProfileComponent";
import SignInComponent from "./Auth/SignInComponent";
import SignUpComponent from "./Auth/SignUpComponent";
import CartComponent from "./Cart/CartComponent";
import CartItemComponent from "./Cart/CartItemComponent";
import CatalogComponent from "./Catalog/CatalogComponent";
import CatalogMainComponent from "./Catalog/CatalogMainComponent";
import ProductAddComponent from "./Catalog/ProductAddComponent";
import ProductChangeComponent from "./Catalog/ProductChangeComponent";
import ProductComponent from "./Catalog/ProductComponent";
import HeaderComponent from "./Header/HeaderComponent";
import MakeAnOrderComponent from "./Order/MakeAnOrderComponent";
import OrdersComponent from "./Order/OrdersComponent";
import { Cart } from "./store/Cart.store";
import { Catalog } from "./store/Catalog.store";

export const cart = new Cart();
export const catalog = new Catalog();

const App = observer(() => {
    return (
        <BrowserRouter>
            <HeaderComponent />
            <div className="container">
                <Routes>
                    <Route path="/catalog" element={<CatalogMainComponent />} />
                    <Route
                        path="/catalog/teapots"
                        element={<CatalogComponent productType="teapots" />}
                    />
                    <Route
                        path="/catalog/coffee-machines"
                        element={
                            <CatalogComponent productType="coffee-machines" />
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
                    <Route path="/register" element={<SignUpComponent />} />
                    <Route path="/profile" element={<ProfileComponent />} />
                    <Route path="/my-orders" element={<OrdersComponent />} />
                    <Route path="/make-an-order" element={<MakeAnOrderComponent />} />
                    <Route
                        path="*"
                        element={<Navigate replace to="/catalog" />}
                    />
                </Routes>
            </div>
            <SignInComponent />
        </BrowserRouter>
    );
});

export default App;
