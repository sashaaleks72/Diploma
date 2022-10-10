import { useEffect, useState } from "react";
import { Accordion } from "react-bootstrap";
import { getUserOrders } from "../http/fetches";
import OrderModel from "../models/OrderModel";

const OrdersComponent = (): JSX.Element => {
    const [orders, setOrders] = useState<OrderModel[]>();

    useEffect(() => {
        const init = async () => {
            const ordersFromResponse = await getUserOrders();

            if (ordersFromResponse) setOrders(ordersFromResponse);
        };

        init();
    }, []);

    return (
        <div>
            <div className="fs-2 text-center mb-2">My orders</div>
            <Accordion>
                {orders?.map((item, index) => {
                    return (
                        <Accordion.Item key={item.id} eventKey={`${index}`}>
                            <Accordion.Header className="d-flex justify-content-end">
                                <div className="">№{item.id}</div>
                                <div className="ms-2">{item.orderDate}</div>
                                <div className="ms-2">{item.orderStatus}</div>
                                <div className="ms-2">
                                    <b>{item.totalSum} ₴</b>
                                </div>
                            </Accordion.Header>
                            <Accordion.Body>
                                <div className="row g-5">
                                    <div className="col-md-7 col-lg-8 order-md-last">
                                        <div
                                            style={{
                                                maxHeight:
                                                    "calc(100vh - 500px)",
                                                overflowX: "hidden",
                                                overflowY: "auto",
                                            }}
                                        >
                                            {item.cartItems.map((product) => (
                                                <div key={product.id}>
                                                    <img
                                                        src={product.imgUrl}
                                                        height="100"
                                                    />
                                                    <div>
                                                        <b>Title: </b>
                                                        {product.title}
                                                    </div>
                                                    <div>
                                                        <b>Quantity: </b>
                                                        {product.quantity}
                                                    </div>
                                                    <div>
                                                        <b>Price: </b>
                                                        {product.price} ₴
                                                    </div>
                                                </div>
                                            ))}
                                        </div>
                                    </div>
                                    <div className="col-md-5 col-lg-4">
                                        <div className="text-secondary">
                                            Information about the order
                                        </div>
                                        <div>
                                            {item.lastName} {item.firstName}{" "}
                                            {item.patronymic}
                                        </div>
                                        <div>м. {item.city}</div>
                                        <div>{item.email}</div>
                                        <div>
                                            {item.department === ""
                                                ? item.deliveryAddress
                                                : item.department}
                                        </div>
                                    </div>
                                </div>
                            </Accordion.Body>
                        </Accordion.Item>
                    );
                })}
            </Accordion>
        </div>
    );
};

export default OrdersComponent;
