import { observer } from "mobx-react-lite";
import { Link, useNavigate } from "react-router-dom";
import { cart, user } from "../App";

type Props = {
    children?: JSX.Element[];
};

const CartComponent = observer((props: Props): JSX.Element => {
    const navigation = useNavigate();

    return (
        <div>
            <div className="fs-2 text-center mb-3">Your cart</div>
            {props.children?.length ? (
                <div>
                    {props.children}
                    <div className="fs-4 text-end mb-3">
                        <b>Total sum: </b>
                        {cart.totalSum} UAH
                    </div>

                    <div className="d-flex justify-content-end">
                        {!user.isAuth && (
                            <div className="text-danger mt-1 me-1">
                                * Please authorize to make an order!
                            </div>
                        )}
                        <button
                            className="btn btn-success float-end mb-2"
                            disabled={!user.isAuth}
                            onClick={() => navigation("/make-an-order")}
                        >
                            Make an order
                        </button>
                    </div>
                </div>
            ) : (
                <div className="fs-1 text-center">Cart is empty!</div>
            )}
        </div>
    );
});

export default CartComponent;
