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
    const [sortParams, setSortParams] = useState<string>("title:asc");
    const [header, setHeader] = useState<string>("Some title");
    const [page, setPage] = useState<number>(1);
    const [totalQuanOfProducts, setTotalQuanOfProducts] = useState<number>(0);

    const limit = 6;

    useEffect(() => {
        setPage(1);
    }, [props.productType]);

    useEffect(() => {
        const init = async () => {
            const totalQuantityOfProds: number = (
                await getProducts(props.productType)
            ).length;
            setTotalQuanOfProducts(totalQuantityOfProds);

            const products: ProductDto[] = await getProducts(
                props.productType,
                sortParams,
                page,
                limit
            );

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

    const previousPage = () => {
        if (page > 1) {
            setPage(page - 1);
        }
    };

    const nextPage = () => {
        const totalPages: number = getTotalPages();

        if (page < totalPages) setPage(page + 1);
    };

    const getTotalPages = (): number => {
        const totalPages: number = Math.ceil(totalQuanOfProducts / limit);

        return totalPages;
    };

    return (
        <div>
            <div className="fs-2 text-center mb-2">{header}</div>

            <select
                className="form-select w-25 mb-3"
                aria-label="Default select example"
                onChange={(e) => setSortParams(e.target.value)}
                value={sortParams}
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
