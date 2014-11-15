var productSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "/Home/Read",
            dataType: "jsonp"
        },
        update: {
            url: "/Home/Update",
            dataType: "jsonp"
        },
        destroy: {
            url: "/Home/Destroy",
            dataType: "jsonp"
        },
        create: {
            url: "/Home/Create",
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
            id: "ITEM_ID",
            fields: {
                ITEM_ID: { editable: true, nullable: false, validation: { required: true } },
                ITEM_NAME: { validation: { required: false } },
                UNIT_ID: { validation: { required: true }, defaultValue: "CAI" },
                ACTIVE: { type: "boolean" }
            }
        }
    },

});