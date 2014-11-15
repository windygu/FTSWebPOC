var invoiceSearchSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "/SaleDetail/SearchInvoice",
            dataType: "jsonp"
        }
    },
    schema: {
        errors: "Errors",
        model: {
            id: "PR_KEY",
            fields: {
                TRAN_NO: {type: "string"},
                TRAN_DATE: {type: "date"},
                ORGANIZATION_ID: {type: "string"},
                ORGANIZATION_NAME: {type: "string"},
                ITEM_ID: {type: "string"},
                ITEM_NAME: { type: "string" },
                QUANTITY: {type: "number"},
                UNIT_PRICE: {type: "number"},
                TOTAL_AMOUNT: {type: "number"}
            }
        }
    }
})