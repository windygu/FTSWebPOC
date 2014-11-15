var customerSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "/Customer/Read",
            dataType: "jsonp"
        },
        update: {
            url: "/Customer/Update",
            dataType: "jsonp"
        },
        destroy: {
            url: "/Customer/Destroy",
            dataType: "jsonp"
        },
        create: {
            url: "/Customer/Create",
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
            id: "PR_DETAIL_ID",
            fields: {
                PR_DETAIL_ID: { editable: true, nullable: false, validation: { required: true } },
                PR_DETAIL_NAME: { validation: { required: true } },
                ADDRESS: { validation: { required: false } },
                TAX_FILE_NUMBER: { validation: { required: true } },
                PHONE: { validation: { required: true } },
                ACTIVE: { type: "boolean", validation: { required: false } },
                IS_PUBLIC: { type: "boolean", validation: { required: false } }
            }
        }
    }
});