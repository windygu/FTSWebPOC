var salePriceSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "/Price/Read",
            dataType: "jsonp"
        },
        update: {
            url: "/Price/Update",
            dataType: "jsonp"
        },
        destroy: {
            url: "/Price/Destroy",
            dataType: "jsonp"
        },
        create: {
            url: "/Price/Create",
            dataType: "jsonp"
        },
        parameterMap: function (options, operation) {
            if (operation !== "read" && options.models) {
                return { models: kendo.stringify(options.models) };
            }
        }
    },
    batch: true,
    pageSize: 10,
    schema: {
        errors: "Errors",
        model: {
            id: "PR_KEY",
            fields: {
                PR_KEY: { editable: false, nullable: false, validation: { required: true } },
                ITEM_ID: { type: "string", validation: { required: true } },
                UNIT_PRICE: { type: "number" },
                VALID_DATE: { type: "date", validation: { required: true } }
            }
        }
    },
   
});



