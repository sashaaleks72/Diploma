import { useEffect, useState } from "react";
import CatalogItemDto from "../dtos/CatalogItemDto";
import { getCatalogItems } from "../http/fetches";
import CatalogMainItemComponent from "./CatalogMainItemComponent";

type Props = {
    children?: JSX.Element[];
};

const CatalogMainComponent = (props: Props): JSX.Element => {
    const [catalogItems, setCatalogItems] = useState<CatalogItemDto[]>([]);

    useEffect(() => {
        const init = async () => {
            const catalogItems: CatalogItemDto[] = await getCatalogItems();
            setCatalogItems(catalogItems);
        };

        init();
    }, []);

    return (
        <div>
            <div className="fs-2 text-center mb-4">Catalog</div>
            <div className="row row-cols-2">
                {catalogItems?.length ? (
                    catalogItems.map((item) => (
                        <CatalogMainItemComponent
                            key={item.id}
                            title={item.title}
                            imgUrl={item.imgUrl}
                            routeName={item.routeName}
                        />
                    ))
                ) : (
                    <div className="fs-1 text-center">Catalog is empty!</div>
                )}
            </div>
        </div>
    );
};

export default CatalogMainComponent;
