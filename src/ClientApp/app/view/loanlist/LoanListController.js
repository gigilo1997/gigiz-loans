Ext.define('ClientApp.view.loanlist.LoanListController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.loanlist-loanlist',

    onButtonNewClick: function(button) {
        var me = this;

        me.getView().destroy();
        Ext.create({
            xtype:'loancreate'
        });
    },

    onLogoutClick: function () {
        var me = this;
        localStorage.removeItem('token');

        me.getView().destroy();
        Ext.create({
            xtype:'login'
        });
    }
});
