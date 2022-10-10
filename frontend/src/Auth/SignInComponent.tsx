import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import SignInModel from "../models/SignInModel";

const SignInComponent = (): JSX.Element => {
    const [signInModel, setSignInModel] = useState<SignInModel>();

    useEffect(() => {
        if (signInModel != undefined) console.log(signInModel);
    }, [signInModel]);

    return (
        <div
            className="modal fade"
            id="exampleModal"
            tab-index="-1"
            aria-labelledby="exampleModalLabel"
            aria-hidden="true"
        >
            <div className="modal-dialog modal-dialog-centered">
                <div className="modal-content">
                    <div className="modal-header">
                        <h1 className="modal-title fs-5" id="exampleModalLabel">
                            Sign In
                        </h1>
                        <button
                            type="button"
                            className="btn-close"
                            data-bs-dismiss="modal"
                            aria-label="Close"
                        ></button>
                    </div>
                    <div className="modal-body">
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
                            <div className="mb-3">
                                <label className="form-label">
                                    Email address
                                </label>
                                <input
                                    name="email"
                                    type="email"
                                    className="form-control"
                                    id="exampleInputEmail1"
                                    aria-describedby="emailHelp"
                                />
                            </div>
                            <div className="mb-3">
                                <label className="form-label">Password</label>
                                <input
                                    name="pass"
                                    type="password"
                                    className="form-control"
                                    id="exampleInputPassword1"
                                />
                            </div>
                            <button type="submit" className="btn btn-primary">
                                Sign In
                            </button>
                            <Link to="/register" style={{ float: "right" }}>
                                <div data-bs-dismiss="modal">
                                    I am not registered
                                </div>
                            </Link>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default SignInComponent;
