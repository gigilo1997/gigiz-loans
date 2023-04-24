Ext.define('ClientApp.view.loanlist.LoansGridController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.loansgrid-loansgrid',

    onButtonEditClick: function(element) {

        var data = element.getWidgetRecord().data;

        var me = this;
        me.getView().destroy();
        Ext.create({
            xtype: 'loanedit',
            record: data
        });
    },
});
