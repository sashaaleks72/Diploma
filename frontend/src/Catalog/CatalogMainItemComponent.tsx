import { Link } from "react-router-dom";

type Props = {
    title: string;
    imgUrl: string;
    routeName: string;
};

const CatalogMainItemComponent = (props: Props): JSX.Element => {
    return (
        <div className="col">
            <div className="card">
                <Link
                    to={`/catalog/${props.routeName}`}
                    className="del_underline"
                >
                    <div className="text-center">
                        <img
                            src={props.imgUrl}
                            alt="product"
                            style={{ height: "200px" }}
                        />
                    </div>
                </Link>
                <div className="card-body">
                    <h5 className="card-title">{props.title}</h5>
                </div>
            </div>
        </div>
    );
};

export default CatalogMainItemComponent;
