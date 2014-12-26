var saleSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "/Sale/Read",
            dataType: "jsonp"
        },
        update: {
            url: "/Sale/Update",
            dataType: "jsonp"
        },
        destroy: {
            url: "/Sale/Destroy",
            dataType: "jsonp"
        },
        create: {
            url: "/Sale/Create",
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
                PR_KEY: { editable: false, nullable: true, type: "string"},
                ORGANIZATION_ID: { editable: true, nullable: true, type: "string"},
                TRAN_ID: { editable: true, nullable: true, type: "string"},
                TRAN_DATE: { editable: true, nullable: true, type: "date"},
                TRAN_NO: { editable: true, nullable: false, validation: { required: true }, type: "string" },
                PR_DETAIL_ID: { editable: true, nullable: false, validation: { required: true }, type: "string" },
                ADDRESS: { editable: true, nullable: false, validation: { required: true }, type: "string" },
                TAX_FILE_NUMBER: { editable: true, nullable: false, validation: { required: true }, type: "string" },
                COMMENTS: { editable: true, nullable: true, type: "string" },
                STATUS: { editable: true, nullable: true, type: "boolean" },
            }
        }
    },
    error: handleError, 
})