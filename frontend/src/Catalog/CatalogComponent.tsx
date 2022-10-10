import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { catalog } from "../App";
import ProductDto from "../dtos/ProductDto";
import { getProducts } from "../http/fetches";
import CatalogItemComponent from "./CatalogItemComponent";

type Props = {
    productType: string;
};

const CatalogComponent = observer((props: Props): JSX.Element => {
    const [sortParams, setSortParams] = useState<string>();
    const [header, setHeader] = useState<string>("Some title");
    const [page, setPage] = useState<number>(1);
    const limit = 6;

    useEffect(() => {
        const init = async () => {
            const products: ProductDto[] = await getProducts(
                props.productType,
                sortParams,
                page,
                limit
            );

            if (!products.length) setPage(page - 1);

            catalog.setProductList(products);
        };

        init();

        if (props.productType) {
            setHeader(
                props.productType[0].toUpperCase() +
                    props.productType.slice(1).replaceAll("-", " ")
            );
        }
    }, [props.productType, sortParams, page]);

    useEffect(() => {
        setPage(1);
    }, [props.productType]);

    const previousPage = () => {
        if (page > 1) {
            setPage(page - 1);
        }
    };

    const nextPage = () => {
        setPage(page + 1);
    };

    return (
        <div>
            <div className="fs-2 text-center mb-2">{header}</div>

            <select
                className="form-select w-25 mb-3"
                aria-label="Default select example"
                onChange={(e) => setSortParams(e.target.value)}
            >
                <option disabled value="">
                    Sorting
                </option>
                <option value="title:asc">Sort by name (asc)</option>
                <option value="title:desc">Sort by name (desc)</option>
            </select>

            <div className="row row-cols-1 row-cols-md-3 g-4">
                {catalog.productList.map((product) => (
                    <CatalogItemComponent
                        key={product.id}
                        id={product.id}
                        title={product.title}
                        quantity={product.quantity}
                        price={product.price}
                        imgUrl={product.imgUrl}
                    />
                ))}
            </div>

            <div className="d-flex justify-content-center">
                <div role="button" className="fs-5" onClick={previousPage}>
                    {" "}
                    &#60;{" "}
                </div>
                <div className="ms-2 fs-5 text-primary"> {page} </div>
                <div role="button" className="ms-2 fs-5" onClick={nextPage}>
                    {" "}
                    &#62;{" "}
                </div>
            </div>
        </div>
    );
});

export default CatalogComponent;
