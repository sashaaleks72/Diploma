import React, { useEffect, useState } from "react";
import SignUpModel from "../models/SignUpModel";
import { useNavigate } from "react-router-dom";
import { user } from "../App";

const SignUpComponent = (): JSX.Element => {
    const navigate = useNavigate();
    const [signUpModel, setSignUpModel] = useState<SignUpModel>();
    const [signUpValidationModel, setSignUpValidationModel] =
        useState<SignUpModel>({
            firstName: "",
            lastName: "",
            patronymic: "",
            birthday: "",
            pass: "",
            email: "",
        });

    const [emailErrorMessage, setEmailErrorMessage] = useState<string>(
        "The email field can't be empty!"
    );
    const [passErrorMessage, setPassErrorMessage] = useState<string>(
        "The password field can't be empty!"
    );
    const [confirmPassErrorMessage, setConfirmPassErrorMessage] =
        useState<string>("The confirm password field can't be empty!");
    const [firstNameErrorMessage, setFirstNameErrorMessage] = useState<string>(
        "The first name field can't be empty!"
    );
    const [lastNameErrorMessage, setLastNameErrorMessage] = useState<string>(
        "The last name field can't be empty!"
    );
    const [patronymicErrorMessage, setPatronymicErrorMessage] =
        useState<string>("The patronymic field can't be empty!");
    const [birthdayErrorMessage, setBirthdayErrorMessage] = useState<string>(
        "The date of birth field can't be empty!"
    );
    const [signUpErrorMessage, setSignUpErrorMessage] = useState<string>("");
    const [confirmPass, setConfirmPass] = useState<string>("");

    const onEmailChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        let re =
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        setSignUpValidationModel({
            ...signUpValidationModel,
            email: e.target.value,
        });

        setSignUpErrorMessage("");

        if (String(e.target.value).toLowerCase().match(re)) {
            setEmailErrorMessage("");
        } else {
            setEmailErrorMessage("Email isn't valid!");
        }
    };

    const onPasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        let re =
            /^(?!.*\s)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[~`!@#$%^&*()--+={}\[\]|\\:;"'<>,.?/_???]).{10,16}$/;

        setSignUpValidationModel({
            ...signUpValidationModel,
            pass: e.target.value,
        });

        if (String(e.target.value).match(re)) {
            setPassErrorMessage("");
        } else {
            setPassErrorMessage("Invalid password!");
        }
    };

    const onConfirmPasswordChange = (
        e: React.ChangeEvent<HTMLInputElement>
    ) => {
        setConfirmPass(e.target.value);

        if (e.target.value !== signUpValidationModel["pass"]) {
            setConfirmPassErrorMessage("Passwords don't match!");
        } else {
            setConfirmPassErrorMessage("");
        }
    };

    const onFirstNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSignUpValidationModel({
            ...signUpValidationModel,
            firstName: e.target.value,
        });

        if (!e.target.value) {
            setFirstNameErrorMessage("The first name field must be filled!");
        } else {
            setFirstNameErrorMessage("");
        }
    };

    const onLastNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSignUpValidationModel({
            ...signUpValidationModel,
            lastName: e.target.value,
        });

        if (!e.target.value) {
            setLastNameErrorMessage("The last name field must be filled!");
        } else {
            setLastNameErrorMessage("");
        }
    };

    const onPatronymicChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSignUpValidationModel({
            ...signUpValidationModel,
            patronymic: e.target.value,
        });

        if (!e.target.value) {
            setPatronymicErrorMessage("The patronymic field must be filled!");
        } else {
            setPatronymicErrorMessage("");
        }
    };

    const onBirthdayChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSignUpValidationModel({
            ...signUpValidationModel,
            birthday: e.target.value,
        });

        if (!e.target.value) {
            setBirthdayErrorMessage("The birthday field must be filled!");
        } else {
            setBirthdayErrorMessage("");
        }
    };

    const [formIsValid, setFormIsValid] = useState<boolean>(false);

    useEffect(() => {
        if (
            emailErrorMessage ||
            passErrorMessage ||
            confirmPassErrorMessage ||
            firstNameErrorMessage ||
            lastNameErrorMessage ||
            patronymicErrorMessage ||
            birthdayErrorMessage
        )
            setFormIsValid(false);
        else setFormIsValid(true);
    }, [
        emailErrorMessage,
        passErrorMessage,
        confirmPassErrorMessage,
        firstNameErrorMessage,
        lastNameErrorMessage,
        patronymicErrorMessage,
        birthdayErrorMessage,
    ]);

    useEffect(() => {
        const init = async () => {
            if (signUpModel) {
                try {
                    await user.signUp(signUpModel);
                    navigate(-1);
                } catch (ex) {
                    let error: string = ex as string;
                    setSignUpErrorMessage(error);
                }
            }
        };

        init();
    }, [signUpModel]);

    return (
        <div>
            <div className="fs-2 text-center mb-2">Sign up</div>
            {signUpErrorMessage && (
                <div className="text-danger w-50 mx-auto">
                    * {signUpErrorMessage}
                </div>
            )}
            <form
                onSubmit={(e) => {
                    e.preventDefault();

                    const target = e.target as typeof e.target & {
                        email: { value: string };
                        pass: { value: string };
                        firstName: { value: string };
                        lastName: { value: string };
                        patronymic: { value: string };
                        birthday: { value: string };
                    };

                    const signUpModel: SignUpModel = {
                        email: target.email.value,
                        pass: target.pass.value,
                        firstName: target.firstName.value,
                        lastName: target.lastName.value,
                        patronymic: target.patronymic.value,
                        birthday: target.birthday.value,
                    };

                    setSignUpModel(signUpModel);
                }}
            >
                <div className="mb-3 w-50 mx-auto">
                    {emailErrorMessage && (
                        <div className="text-danger">* {emailErrorMessage}</div>
                    )}
                    <label className="form-label fs-4">Email</label>
                    <input
                        type="text"
                        className="form-control"
                        name="email"
                        value={signUpValidationModel["email"]}
                        onChange={(e) => onEmailChange(e)}
                        required
                    />
                </div>
                <div className="mb-3 w-50 mx-auto">
                    {passErrorMessage && (
                        <div className="text-danger">* {passErrorMessage}</div>
                    )}
                    <label className="form-label fs-4">Password</label>
                    <input
                        type="password"
                        className="form-control"
                        name="pass"
                        value={signUpValidationModel["pass"]}
                        onChange={(e) => onPasswordChange(e)}
                        required
                    />
                </div>

                <div className="mb-3 w-50 mx-auto">
                    {confirmPassErrorMessage && (
                        <div className="text-danger">
                            * {confirmPassErrorMessage}
                        </div>
                    )}
                    <label className="form-label fs-4">Confirm password</label>
                    <input
                        type="password"
                        className="form-control"
                        name="confirmPass"
                        value={confirmPass}
                        onChange={(e) => onConfirmPasswordChange(e)}
                        required
                    />
                </div>
                <div className="mb-3 w-50 mx-auto">
                    {firstNameErrorMessage && (
                        <div className="text-danger">
                            * {firstNameErrorMessage}
                        </div>
                    )}
                    <label className="form-label fs-4">First name</label>
                    <input
                        type="text"
                        className="form-control"
                        name="firstName"
                        value={signUpValidationModel["firstName"]}
                        onChange={(e) => onFirstNameChange(e)}
                        required
                    />
                </div>
                <div className="mb-3 w-50 mx-auto">
                    {lastNameErrorMessage && (
                        <div className="text-danger">
                            * {lastNameErrorMessage}
                        </div>
                    )}
                    <label className="form-label fs-4">Last name</label>
                    <input
                        type="text"
                        className="form-control"
                        name="lastName"
                        value={signUpValidationModel["lastName"]}
                        onChange={(e) => onLastNameChange(e)}
                        required
                    />
                </div>
                <div className="mb-3 w-50 mx-auto">
                    {patronymicErrorMessage && (
                        <div className="text-danger">
                            * {patronymicErrorMessage}
                        </div>
                    )}
                    <label className="form-label fs-4">Patronymic</label>
                    <input
                        type="text"
                        className="form-control"
                        name="patronymic"
                        value={signUpValidationModel["patronymic"]}
                        onChange={(e) => onPatronymicChange(e)}
                        required
                    />
                </div>
                <div className="mb-3 w-50 mx-auto">
                    {birthdayErrorMessage && (
                        <div className="text-danger">
                            * {birthdayErrorMessage}
                        </div>
                    )}
                    <label className="form-label fs-4">Date of birth</label>
                    <input
                        type="date"
                        className="form-control"
                        name="birthday"
                        onChange={(e) => onBirthdayChange(e)}
                        required
                    />
                </div>

                <div className="text-center">
                    <button
                        disabled={!formIsValid}
                        type="submit"
                        className="btn btn-primary"
                    >
                        Sign up
                    </button>
                </div>
            </form>
        </div>
    );
};

export default SignUpComponent;
