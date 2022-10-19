import { Link } from "react-router-dom";
import "../App.css";
import shoppingCart from "../images/icons/shopping-bag.svg";
import auth from "../images/icons/auth.svg";
import authenticated from "../images/icons/authenticated.svg";
import { useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import { user } from "../App";
import { Button } from "react-bootstrap";
import SignInComponent from "../Auth/SignInComponent";

const HeaderComponent = observer((): JSX.Element => {
    const [isSignInModalDisplayed, setSignInModalDisplayed] =
        useState<boolean>(false);

    return (
        <nav className="navbar navbar-expand-lg bg-light">
            <div className="container-fluid">
                <Link to="/catalog" className="del_underline">
                    <div className="navbar-brand">TeapotShop</div>
                </Link>
                <button
                    className="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarNavAltMarkup"
                    aria-controls="navbarNavAltMarkup"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                >
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div
                    className="collapse navbar-collapse"
                    id="navbarNavAltMarkup"
                >
                    <div className="navbar-nav">
                        <li className="nav-item dropdown">
                            <div
                                className="nav-link dropdown-toggle"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                                role="button"
                            >
                                Catalog
                            </div>
                            <ul className="dropdown-menu dropdown-menu-dark">
                                <li>
                                    <Link
                                        to="/catalog/teapots"
                                        className="dropdown-item"
                                    >
                                        Teapots
                                    </Link>
                                </li>
                                <li>
                                    <Link
                                        to="/catalog/coffee-machines"
                                        className="dropdown-item"
                                    >
                                        Coffee machines
                                    </Link>
                                </li>
                            </ul>
                        </li>
                        {user.isAuth && (
                            <Link to="/my-orders" className="del_underline">
                                <div className="nav-link" aria-current="page">
                                    My orders
                                </div>
                            </Link>
                        )}
                    </div>
                </div>

                {user.isAuth && (
                    <div
                        className="nav-link"
                        onClick={() => {
                            user.signOut();
                            user.setAuth(false);
                        }}
                        aria-current="page"
                        role="button"
                    >
                        Logout
                    </div>
                )}

                {user.isAuth ? (
                    <Link className="del_underline ms-1" to="/profile">
                        <img
                            src={authenticated}
                            width="25px"
                            alt="authenticated"
                        ></img>
                    </Link>
                ) : (
                    <div
                        role="button"
                        onClick={() => setSignInModalDisplayed(true)}
                    >
                        <img src={auth} width="25px" alt="auth"></img>
                    </div>
                )}
                <SignInComponent
                    show={isSignInModalDisplayed}
                    setSignInModalDisplayed={(isSignInModalDisplayed: boolean | ((prevState: boolean) => boolean)) => setSignInModalDisplayed(isSignInModalDisplayed)}
                />

                <Link to="/cart" className="del_underline ms-1">
                    <img
                        src={shoppingCart}
                        width="25px"
                        alt="shopping-cart"
                    ></img>
                </Link>
            </div>
        </nav>
    );
});

export default HeaderComponent;
