import { Link } from "react-router-dom";
import "../App.css";
import shoppingCart from "../images/icons/shopping-bag.svg";
import auth from "../images/icons/auth.svg";
import authenticated from "../images/icons/authenticated.svg";
import { useEffect, useState } from "react";

const HeaderComponent = (): JSX.Element => {
    const [isAuthenticated, setAuthState] = useState<boolean>(false);

    useEffect(() => {
        setAuthState(false);
    }, []);

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
                        {isAuthenticated && (
                            <Link to="/my-orders" className="del_underline">
                                <div className="nav-link" aria-current="page">
                                    My orders
                                </div>
                            </Link>
                        )}
                    </div>
                </div>
                {isAuthenticated ? (
                    <Link className="del_underline" to="/profile">
                        <img
                            src={authenticated}
                            width="25px"
                            alt="authenticated"
                        ></img>
                    </Link>
                ) : (
                    <Link
                        className="del_underline"
                        to="#"
                        data-bs-toggle="modal"
                        data-bs-target="#exampleModal"
                    >
                        <img src={auth} width="25px" alt="auth"></img>
                    </Link>
                )}

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
};

export default HeaderComponent;
