var invoiceSource =  new kendo.data.DataSource({
    transport: {
        read: {
            url: "/SaleDetail/Read",
            dataType: "jsonp"
        },
        update: {
            url: "/SaleDetail/Update",
            dataType: "jsonp"
        },
        destroy: {
            url: "/SaleDetail/Destroy",
            dataType: "jsonp"
        },
        create: {
            url: "/SaleDetail/Create",
            dataType: "jsonp"
        },
        parameterMap: function (options, operation) {
            if (operation !== "read" && options.models) {
                return { models: kendo.stringify(options.models) };
            }
        }
    },
    batch: true,
    schema: {
        errors: "Errors",
        model: {
            id: "PR_KEY",
            fields: {
                FR_KEY: { editable: true, nullable: true},
                LIST_ORDER: { editable: true, nullable: true},
                ITEM_ID: { editable: true, nullable: false, validation: { required: true } },
                ITEM_NAME: { editable: true, nullable: false, validation: { required: true } },
                QUANTITY: { editable: true, nullable: false, validation: { required: true } },
                UNIT_PRICE: { editable: true, nullable: false, validation: { required: true } },
                AMOUNT: { editable: true, nullable: false, validation: { required: true } },
                VAT_TAX_RATE: { editable: true, nullable: true},
                VAT_TAX_AMOUNT: { editable: true, nullable: true},
                TOTAL_AMOUNT: { editable: true, nullable: false, validation: { required: true } }
            }
        }
    }
})