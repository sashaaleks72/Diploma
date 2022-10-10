import { useEffect, useState } from "react";
import { Spinner } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { cart } from "../App";
import { getDepartments, makeAnOrder } from "../http/fetches";
import OrderModel from "../models/OrderModel";

const MakeAnOrderComponent = (): JSX.Element => {
    const [selectedCity, setSelectedCity] = useState<string>("");
    const [typeOfDelivery, setDeliveryType] = useState<string>();
    const [deliveryAddress, setDeliveryAddress] = useState<string>("");
    const [departments, setDepartments] = useState<string[]>([]);
    const [department, setDepartment] = useState<string>("");
    const [isNotFoundCity, setIsNotFoundCity] = useState<boolean>(false);
    const [order, setOrder] = useState<OrderModel>();

    const [cities] = useState([
        {
            value: "Харків",
            name: "Kharkiv",
        },
        {
            value: "Київ",
            name: "Kyiv",
        },
        {
            value: "Одеса",
            name: "Odessa",
        },
        {
            value: "Запоріжжя",
            name: "Zaporizhzhia",
        },
        {
            value: "Львів",
            name: "Lviv",
        },
    ]);

    const navigate = useNavigate();

    useEffect(() => {
        const init = async () => {
            setDepartments([]);

            if (typeOfDelivery === "nova poshta" && selectedCity != "") {
                const departmentsFromResponse: string[] = await getDepartments(
                    selectedCity
                );

                setDepartments(departmentsFromResponse);
            }
        };

        init();
    }, [typeOfDelivery, selectedCity]);

    useEffect(() => {
        const init = async () => {
            if (order != undefined) {
                await makeAnOrder(order);
                cart.clearCart();
                navigate(-2);
            }
        };

        init();
    }, [order]);

    return (
        <div className="mt-3">
            <form
                className="row g-5"
                onSubmit={(e) => {
                    e.preventDefault();

                    const currentDate = new Date();

                    const target = e.target as typeof e.target & {
                        email: { value: string };
                        pass: { value: string };
                        firstName: { value: string };
                        lastName: { value: string };
                        patronymic: { value: string };
                        birthday: { value: string };
                    };

                    const orderModel: OrderModel = {
                        id: "",
                        firstName: target.firstName.value,
                        lastName: target.lastName.value,
                        patronymic: target.patronymic.value,
                        email: target.email.value,
                        city: selectedCity,
                        department,
                        deliveryAddress,
                        cartItems: cart.cartItems,
                        orderStatus: "Waiting for accept",
                        orderDate: `${currentDate.getDate()}.${currentDate.getMonth()}.${currentDate.getFullYear()}`,
                        totalSum: cart.totalSum,
                    };

                    setOrder(orderModel);
                }}
            >
                <div className="col-md-5 col-lg-4 order-md-last">
                    <h4 className="d-flex justify-content-between mb-3">
                        <span className="text-primary">Your cart</span>
                        <span className="badge bg-primary rounded-pill">
                            {cart.cartItems.length}
                        </span>
                    </h4>
                    <div
                        style={{
                            maxHeight: "calc(100vh - 400px)",
                            overflowX: "hidden",
                            overflowY: "auto",
                        }}
                    >
                        {cart.cartItems.map((item) => (
                            <div key={item.id}>
                                <img
                                    src={item.imgUrl}
                                    alt="cart-item"
                                    height={100}
                                />
                                <div>
                                    <b>Title: </b>
                                    {item.title}
                                </div>
                                <div>
                                    <b>Quantity: </b>
                                    {item.quantity}
                                </div>
                                <div>
                                    <b>Price: </b>
                                    {item.price} ₴
                                </div>
                            </div>
                        ))}
                    </div>
                    <hr />
                    <h5>Total: {cart.totalSum} ₴</h5>
                </div>
                <div className="col-md-7 col-lg-8">
                    <h4>Contact information and delivery</h4>
                    <hr className="my-4" />
                    <h4>1. Contact information</h4>
                    <div className="">
                        <label className="form-label">First name</label>
                        <input
                            type="text"
                            name="firstName"
                            className="form-control"
                            placeholder="Enter your first name"
                            required
                        />
                    </div>
                    <div className="mt-2">
                        <label className="form-label">Last name</label>
                        <input
                            type="text"
                            name="lastName"
                            className="form-control"
                            placeholder="Enter your last name"
                            required
                        />
                    </div>

                    <div className="mt-2">
                        <label className="form-label">Patronymic</label>
                        <input
                            type="text"
                            name="patronymic"
                            className="form-control"
                            placeholder="Enter your patronymic"
                            required
                        />
                    </div>

                    <div className="mt-2">
                        <label className="form-label">Email</label>
                        <input
                            type="email"
                            name="email"
                            className="form-control"
                            placeholder="Enter your email"
                            required
                        />
                    </div>

                    <hr className="my-4" />
                    <h4>2. Delivery</h4>

                    <div className="mt-2">
                        <label className="form-label">City</label>

                        {!isNotFoundCity ? (
                            <select
                                className="form-select"
                                value={selectedCity}
                                onChange={(e) =>
                                    setSelectedCity(e.target.value)
                                }
                                required
                            >
                                <option disabled value="">
                                    Choose...
                                </option>
                                {cities.map((option) => {
                                    return (
                                        <option
                                            key={option.name}
                                            value={option.value}
                                        >
                                            {option.name}
                                        </option>
                                    );
                                })}
                            </select>
                        ) : (
                            <input
                                type="text"
                                className="form-control"
                                value={selectedCity}
                                onChange={(e) =>
                                    setSelectedCity(e.target.value)
                                }
                            ></input>
                        )}
                    </div>

                    <div className="mt-2 form-check">
                        <label className="form-check-label">
                            <input
                                type="checkbox"
                                className="form-check-input"
                                name="notfoundcity"
                                onChange={(e) =>
                                    setIsNotFoundCity(e.target.checked)
                                }
                            />
                            I didn't find the required city in this list
                        </label>
                    </div>

                    <div className="mt-2 form-check">
                        <input
                            type="radio"
                            className="form-check-input"
                            name="delivery"
                            onChange={(e) => setDeliveryType(e.target.value)}
                            value="courier"
                            required
                        />
                        <label className="form-check-label">
                            Courier delivery
                        </label>
                    </div>
                    <div className="mt-2 form-check">
                        <input
                            type="radio"
                            className="form-check-input"
                            name="delivery"
                            onChange={(e) => setDeliveryType(e.target.value)}
                            required
                            value="nova poshta"
                        />
                        <label className="form-check-label">
                            Delivery to the Nova Poshta post office
                        </label>
                    </div>
                    {typeOfDelivery === "courier" && (
                        <div className="mt-2">
                            <label className="form-label">
                                Delivery address
                            </label>
                            <input
                                type="text"
                                className="form-control"
                                name="deliveryAddress"
                                value={deliveryAddress}
                                onChange={(e) =>
                                    setDeliveryAddress(e.target.value)
                                }
                                required
                                placeholder="Enter delivery address"
                            ></input>
                        </div>
                    )}

                    {typeOfDelivery === "nova poshta" && (
                        <div className="mt-2">
                            <label className="form-label">Department</label>

                            <div className="d-flex justify-content-between">
                                <select
                                    className="form-select"
                                    onChange={(e) =>
                                        setDepartment(e.target.value)
                                    }
                                    required
                                    disabled={!Boolean(departments.length)}
                                >
                                    <option disabled value="">
                                        Choose...
                                    </option>
                                    {departments?.map((department, index) => {
                                        return (
                                            <option
                                                value={department}
                                                key={index}
                                            >
                                                {department}
                                            </option>
                                        );
                                    })}
                                </select>
                                {!Boolean(departments.length) &&
                                    selectedCity && (
                                        <Spinner
                                            animation="border"
                                            className="ms-1"
                                        />
                                    )}
                            </div>
                        </div>
                    )}

                    <hr className="my-4" />
                    <div className="text-center mt-2">
                        <button type="submit" className="btn btn-primary">
                            Confirm the order
                        </button>
                    </div>
                </div>
            </form>
        </div>
    );
};

export default MakeAnOrderComponent;
