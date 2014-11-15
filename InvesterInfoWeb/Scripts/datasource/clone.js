
function cloneDataSource(dataSource) {
    var clone = new kendo.data.DataSource();
    dataSource.bind("change",function () {
        clone.data(this.data());
    });

    
    return clone;
}


