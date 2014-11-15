(function ($) {

    var kendo = window.kendo,
        ui = kendo.ui,
        Widget = ui.Widget,
        CHANGE = "change",
        DATABINDING = "dataBinding",
        DATABOUND = "dataBound";

    var FtsTemplatedWidget = kendo.ui.Widget.extend({
        init: function(element, options) {
            var that = this;
            kendo.ui.Widget.fn.init.call(that, element, options);
            that.template = kendo.template(that.options.template);
            // initialize or create dataSource
            that._dataSource();
        },

        refresh: function() {
            var that = this,
                view = that.dataSource.view(),
                html = kendo.render(that.template, view);

            // trigger the dataBinding event
            that.trigger(DATABINDING);

            // mutate the DOM (AKA build the widget UI)
            that.element.html(html);

            // trigger the dataBound event
            that.trigger(DATABOUND);
        },

        options: {
            name: "ftsTemplatedWidget",
            autoBind: true,
            template: ""
            },
        _dataSource: function () {
            var that = this;
            
            // if the DataSource is defined and the _refreshHandler is wired up, unbind because
            // we need to rebuild the DataSource
            if (that.dataSource && that._refreshHandler) {
                that.dataSource.unbind(CHANGE, that._refreshHandler);
            }
            else {
                that._refreshHandler = $.proxy(that.refresh, that);
            }

            // returns the datasource OR creates one if using array or configuration
            that.dataSource = kendo.data.DataSource.create(that.options.dataSource);
            
            // bind to the change event to refresh the widget
            that.dataSource.bind(CHANGE, that._refreshHandler);

            // trigger a read on the dataSource if one hasn't happened yet
            if (that.options.autoBind) {
                that.dataSource.fetch();
            }
        },
        
        // for supporting changing the datasource via MVVM
        setDataSource: function (dataSource) {
            // set the internal datasource equal to the one passed in by MVVM
            this.options.dataSource = dataSource;
            // rebuild the datasource if necessary, or just reassign
            this._dataSource();
        }, 
        
        // events are used by other widgets / developers - API for other purposes
        // these events support MVVM bound items in the template. for loose coupling with MVVM.
        events: [
            // call before mutating DOM.
            // mvvm will traverse DOM, unbind any bound elements or widgets
            DATABINDING,
            // call after mutating DOM
            // traverses DOM and binds ALL THE THINGS
            DATABOUND
        ],
        
        items: function () {
            return this.element.children();
        },
    });

    kendo.ui.plugin(FtsTemplatedWidget);

})(jQuery);