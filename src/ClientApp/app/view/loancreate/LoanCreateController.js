Ext.define('ClientApp.view.loancreate.LoanCreateController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.loancreate-loancreate',

    onButtonCreateClick: function(button) {
        var me = this;

        var form = this.lookup('loancreateform');
        if (form.isValid()) {
            form.submit({
                url: 'https://localhost:7000/api/Loan/CreateLoan',
                method: 'POST',
                headers: {
                    "Authorization": 'Bearer ' + localStorage.getItem('token')
                },
                success: function(response, action) {
                    me.getView().destroy();
                    Ext.create({
                        xtype:'loanlist'
                    });
                    window.location.reload();
                },
                failure: function(response, action) {
                    Ext.Msg.alert('Error', "Could not create loan");
                }
            });
        }
    },
    onButtonCancelClick: function(button) {
        var me = this;

        me.getView().destroy();
        Ext.create({
            xtype:'loanlist'
        });
    }
});
