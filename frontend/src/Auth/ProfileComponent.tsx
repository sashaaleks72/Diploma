import { useEffect, useState } from "react";
import { editProfile, getProfile } from "../http/fetches";
import ProfileModel from "../models/ProfileModel";

const ProfileComponent = (): JSX.Element => {
    const [profile, setProfile] = useState<ProfileModel>();

    const [validationProfile, setValidationProfile] = useState<ProfileModel>({
        firstName: "",
        lastName: "",
        patronymic: "",
        birthday: "",
    });

    const [firstNameErrorMessage, setFirstNameErrorMessage] =
        useState<string>("");
    const [lastNameErrorMessage, setLastNameErrorMessage] =
        useState<string>("");
    const [patronymicErrorMessage, setPatronymicErrorMessage] =
        useState<string>("");
    const [birthdayErrorMessage, setBirthdayErrorMessage] =
        useState<string>("");

    const onFirstNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setValidationProfile({
            ...validationProfile,
            firstName: e.target.value,
        });

        if (!e.target.value) {
            setFirstNameErrorMessage("The first name field must be filled!");
        } else {
            setFirstNameErrorMessage("");
        }
    };

    const onLastNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setValidationProfile({
            ...validationProfile,
            lastName: e.target.value,
        });

        if (!e.target.value) {
            setLastNameErrorMessage("The last name field must be filled!");
        } else {
            setLastNameErrorMessage("");
        }
    };

    const onPatronymicChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setValidationProfile({
            ...validationProfile,
            patronymic: e.target.value,
        });

        if (!e.target.value) {
            setPatronymicErrorMessage("The patronymic field must be filled!");
        } else {
            setPatronymicErrorMessage("");
        }
    };

    const onBirthdayChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setValidationProfile({
            ...validationProfile,
            birthday: e.target.value,
        });

        if (!e.target.value) {
            setBirthdayErrorMessage("The birthday field must be filled!");
        } else {
            setBirthdayErrorMessage("");
        }
    };

    const [isAllowToEdit, setAllowanceToEdit] = useState<boolean>(false);
    const [formIsValid, setFormIsValid] = useState<boolean>(false);

    useEffect(() => {
        if (
            firstNameErrorMessage ||
            lastNameErrorMessage ||
            patronymicErrorMessage ||
            birthdayErrorMessage
        )
            setFormIsValid(false);
        else setFormIsValid(true);
    }, [
        firstNameErrorMessage,
        lastNameErrorMessage,
        patronymicErrorMessage,
        birthdayErrorMessage,
    ]);

    useEffect(() => {
        const init = async () => {
            const profileFromResponse = await getProfile("ES9zC9J");
            setValidationProfile(profileFromResponse);
        };

        init();
    }, []);

    useEffect(() => {
        const init = async () => {
            if (profile != undefined) await editProfile("ES9zC9J", profile);
        };

        init();
    }, [profile]);

    return (
        <div>
            <div className="fs-2 text-center mb-2">Your profile</div>
            <form
                onSubmit={(e) => {
                    e.preventDefault();

                    console.log("hello");

                    const target = e.target as typeof e.target & {
                        firstName: { value: string };
                        lastName: { value: string };
                        patronymic: { value: string };
                        birthday: { value: string };
                    };

                    const profile: ProfileModel = {
                        firstName: target.firstName.value,
                        lastName: target.lastName.value,
                        patronymic: target.patronymic.value,
                        birthday: target.birthday.value,
                    };

                    setProfile(profile);
                    setAllowanceToEdit(false);
                }}
            >
                <div className="mb-3 w-50 mx-auto">
                    {firstNameErrorMessage && (
                        <div className="text-danger">
                            * {firstNameErrorMessage}
                        </div>
                    )}
                    <label className="form-label fs-4">First name</label>
                    <input
                        disabled={!isAllowToEdit}
                        type="text"
                        className="form-control"
                        name="firstName"
                        value={validationProfile["firstName"]}
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
                        disabled={!isAllowToEdit}
                        type="text"
                        className="form-control"
                        name="lastName"
                        value={validationProfile["lastName"]}
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
                        disabled={!isAllowToEdit}
                        type="text"
                        className="form-control"
                        name="patronymic"
                        value={validationProfile["patronymic"]}
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
                        disabled={!isAllowToEdit}
                        type="date"
                        className="form-control"
                        name="birthday"
                        value={validationProfile["birthday"]}
                        onChange={(e) => onBirthdayChange(e)}
                        required
                    />
                </div>

                <div className="text-center">
                    {!isAllowToEdit && (
                        <div
                            className="btn btn-success"
                            role="button"
                            onClick={(e) => setAllowanceToEdit(true)}
                        >
                            Edit profile
                        </div>
                    )}
                    <input
                        disabled={!formIsValid}
                        type={isAllowToEdit ? "submit" : "hidden"}
                        className="btn btn-primary"
                        value={"Save changes"}
                    />
                </div>
            </form>
        </div>
    );
};

export default ProfileComponent;
