Ext.define('ClientApp.view.loanedit.LoanEditController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.loanedit-loanedit',

    record: null,

    // Record not passed
    getLoanData: function() {
        return this.record;
    },

    onButtonSubmitClick: function(button) {
        var me = this;

        console.log(me.getLoanData());

        var form = this.lookup('loaneditform');
        if (form.isValid()) {
            form.submit({
                url: 'https://localhost:7000/api/Loan/EditLoan',
                method: 'PUT',
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
