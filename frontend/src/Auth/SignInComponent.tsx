import { MouseEventHandler, useEffect, useState } from "react";
import { Button, Modal } from "react-bootstrap";
import { Link } from "react-router-dom";
import { user } from "../App";
import SignInModel from "../models/SignInModel";

type Props = {
    show: boolean;
    setSignInModalDisplayed: any;
};

const SignInComponent = (props: Props): JSX.Element => {
    const [signInModel, setSignInModel] = useState<SignInModel>();
    const [signInErrorMessage, setSignInErrorMessage] = useState<string>("");

    useEffect(() => {
        const init = async () => {
            if (signInModel != undefined) {
                try {
                    await user.signIn(signInModel);
                    props.setSignInModalDisplayed(false);
                } catch (ex) {
                    let error: string = ex as string;
                    setSignInErrorMessage(error);
                }
            }
        };

        init();
    }, [signInModel]);

    return (
        <Modal
            show={props.show}
            onHide={() => props.setSignInModalDisplayed(false)}
            aria-labelledby="contained-modal-title-vcenter"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    <h1 className="modal-title fs-5" id="exampleModalLabel">
                        Sign In
                    </h1>
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <form
                    onSubmit={(e) => {
                        e.preventDefault();

                        const target = e.target as typeof e.target & {
                            email: { value: string };
                            pass: { value: string };
                        };

                        const signInModel: SignInModel = {
                            email: target.email.value,
                            pass: target.pass.value,
                        };

                        setSignInModel(signInModel);
                    }}
                >
                    {signInErrorMessage && (
                        <div className="text-danger">
                            * {signInErrorMessage}
                        </div>
                    )}
                    <div className="mb-3">
                        <label className="form-label">Email address</label>
                        <input
                            name="email"
                            type="email"
                            className="form-control"
                            id="exampleInputEmail1"
                            aria-describedby="emailHelp"
                            onChange={() => setSignInErrorMessage("")}
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Password</label>
                        <input
                            name="pass"
                            type="password"
                            className="form-control"
                            id="exampleInputPassword1"
                            onChange={() => setSignInErrorMessage("")}
                        />
                    </div>
                    <button type="submit" className="btn btn-primary">
                        Sign In
                    </button>
                    <Link to="/register" style={{ float: "right" }}>
                        <div
                            onClick={() => props.setSignInModalDisplayed(false)}
                        >
                            I am not registered
                        </div>
                    </Link>
                </form>
            </Modal.Body>
        </Modal>
    );
};

export default SignInComponent;
