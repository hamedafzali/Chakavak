'------------------------------------------------------------------------------
'THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
'FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
'DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
'ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
'------------------------------------------------------------------------------


Namespace com.cbi.chakavak.chequeSchema
    '''
     _
    Partial Public Class Cheque
        Private headerField As Header
        Private bodyField As Body
        '''
        Public Property Header() As Header
            Get
                Return Me.headerField
            End Get
            Set(value As Header)
                Me.headerField = value
            End Set
        End Property
        '''
        Public Property Body() As Body
            Get
                Return Me.bodyField
            End Get
            Set(value As Body)
                Me.bodyField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class Header
        Private chequeIDField As String
        Private depositDateField As String
        Private settlementDateField As String
        Private amountField As String
        Private userNameField As String
        '''
        Public Property ChequeID() As String
            Get
                Return Me.chequeIDField
            End Get
            Set(value As String)
                Me.chequeIDField = value
            End Set
        End Property
        '''
        Public Property DepositDate() As String
            Get
                Return Me.depositDateField
            End Get
            Set(value As String)
                Me.depositDateField = value
            End Set
        End Property
        '''
        Public Property SettlementDate() As String
            Get
                Return Me.settlementDateField
            End Get
            Set(value As String)
                Me.settlementDateField = value
            End Set
        End Property
        '''
        Public Property Amount() As String
            Get
                Return Me.amountField
            End Get
            Set(value As String)
                Me.amountField = value
            End Set
        End Property
        '''
        Public Property UserName() As String
            Get
                Return Me.userNameField
            End Get
            Set(value As String)
                Me.userNameField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class Body
        Private itemField As Object
        '''
        _
        Public Property Item() As Object
            Get
                Return Me.itemField
            End Get
            Set(value As Object)
                Me.itemField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class Acknowledge
        Private tRNField As String
        Private statusField As String
        Private reasonField As String
        Private debtorField As Debtor
        Private creditorField As Creditor
        '''
        Public Property TRN() As String
            Get
                Return Me.tRNField
            End Get
            Set(value As String)
                Me.tRNField = value
            End Set
        End Property
        '''
        Public Property Status() As String
            Get
                Return Me.statusField
            End Get
            Set(value As String)
                Me.statusField = value
            End Set
        End Property
        '''
        Public Property Reason() As String
            Get
                Return Me.reasonField
            End Get
            Set(value As String)
                Me.reasonField = value
            End Set
        End Property
        '''
        Public Property Debtor() As Debtor
            Get
                Return Me.debtorField
            End Get
            Set(value As Debtor)
                Me.debtorField = value
            End Set
        End Property
        '''
        Public Property Creditor() As Creditor
            Get
                Return Me.creditorField
            End Get
            Set(value As Creditor)
                Me.creditorField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class Debtor
        Private nameField As String
        Private iBANField As String
        Private bICField As String
        Private branchCodeField As String
        '''
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set(value As String)
                Me.nameField = value
            End Set
        End Property
        '''
        Public Property IBAN() As String
            Get
                Return Me.iBANField
            End Get
            Set(value As String)
                Me.iBANField = value
            End Set
        End Property
        '''
        Public Property BIC() As String
            Get
                Return Me.bICField
            End Get
            Set(value As String)
                Me.bICField = value
            End Set
        End Property
        '''
        Public Property BranchCode() As String
            Get
                Return Me.branchCodeField
            End Get
            Set(value As String)
                Me.branchCodeField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class Creditor
        Private nameField As String
        Private iBANField As String
        Private nationalCodeField As String
        Private bICField As String
        Private branchCodeField As String
        '''
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set(value As String)
                Me.nameField = value
            End Set
        End Property
        '''
        Public Property IBAN() As String
            Get
                Return Me.iBANField
            End Get
            Set(value As String)
                Me.iBANField = value
            End Set
        End Property
        '''
        Public Property NationalCode() As String
            Get
                Return Me.nationalCodeField
            End Get
            Set(value As String)
                Me.nationalCodeField = value
            End Set
        End Property
        '''
        Public Property BIC() As String
            Get
                Return Me.bICField
            End Get
            Set(value As String)
                Me.bICField = value
            End Set
        End Property
        '''
        Public Property BranchCode() As String
            Get
                Return Me.branchCodeField
            End Get
            Set(value As String)
                Me.branchCodeField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class Action
        Private seqNoField As String
        Private eventField As String
        Private debtorBicField As String
        Private creditorBicField As String
        Private tRNField As String
        '''
        Public Property SeqNo() As String
            Get
                Return Me.seqNoField
            End Get
            Set(value As String)
                Me.seqNoField = value
            End Set
        End Property
        '''
        Public Property [Event]() As String
            Get
                Return Me.eventField
            End Get
            Set(value As String)
                Me.eventField = value
            End Set
        End Property
        '''
        Public Property DebtorBic() As String
            Get
                Return Me.debtorBicField
            End Get
            Set(value As String)
                Me.debtorBicField = value
            End Set
        End Property
        '''
        Public Property CreditorBic() As String
            Get
                Return Me.creditorBicField
            End Get
            Set(value As String)
                Me.creditorBicField = value
            End Set
        End Property
        '''
        Public Property TRN() As String
            Get
                Return Me.tRNField
            End Get
            Set(value As String)
                Me.tRNField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class Request
        Private submitterField As String
        Private priorityField As String
        Private seqNoField As String
        Private partialSettlementField As Boolean
        Private partialSettlementFieldSpecified As Boolean
        Private codedField As Boolean
        Private prominentStampField As Boolean
        Private regressiveField As String
        Private instrIdField As String
        Private debtorField As Debtor
        Private creditorField As Creditor
        Private requestDataField As RequestData
        '''
        Public Property Submitter() As String
            Get
                Return Me.submitterField
            End Get
            Set(value As String)
                Me.submitterField = value
            End Set
        End Property
        '''
        Public Property Priority() As String
            Get
                Return Me.priorityField
            End Get
            Set(value As String)
                Me.priorityField = value
            End Set
        End Property
        '''
        Public Property SeqNo() As String
            Get
                Return Me.seqNoField
            End Get
            Set(value As String)
                Me.seqNoField = value
            End Set
        End Property
        '''
        Public Property PartialSettlement() As Boolean
            Get
                Return Me.partialSettlementField
            End Get
            Set(value As Boolean)
                Me.partialSettlementField = value
            End Set
        End Property
        '''
        _
        Public Property PartialSettlementSpecified() As Boolean
            Get
                Return Me.partialSettlementFieldSpecified
            End Get
            Set(value As Boolean)
                Me.partialSettlementFieldSpecified = value
            End Set
        End Property
        '''
        Public Property Coded() As Boolean
            Get
                Return Me.codedField
            End Get
            Set(value As Boolean)
                Me.codedField = value
            End Set
        End Property
        '''
        Public Property ProminentStamp() As Boolean
            Get
                Return Me.prominentStampField
            End Get
            Set(value As Boolean)
                Me.prominentStampField = value
            End Set
        End Property
        '''
        Public Property Regressive() As String
            Get
                Return Me.regressiveField
            End Get
            Set(value As String)
                Me.regressiveField = value
            End Set
        End Property
        '''
        Public Property InstrId() As String
            Get
                Return Me.instrIdField
            End Get
            Set(value As String)
                Me.instrIdField = value
            End Set
        End Property
        '''
        Public Property Debtor() As Debtor
            Get
                Return Me.debtorField
            End Get
            Set(value As Debtor)
                Me.debtorField = value
            End Set
        End Property
        '''
        Public Property Creditor() As Creditor
            Get
                Return Me.creditorField
            End Get
            Set(value As Creditor)
                Me.creditorField = value
            End Set
        End Property
        '''
        Public Property RequestData() As RequestData
            Get
                Return Me.requestDataField
            End Get
            Set(value As RequestData)
                Me.requestDataField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class RequestData
        Private frontField() As Byte
        Private backField() As Byte
        '''
        _
        Public Property Front() As Byte()
            Get
                Return Me.frontField
            End Get
            Set(value As Byte())
                Me.frontField = value
            End Set
        End Property
        '''
        _
        Public Property Back() As Byte()
            Get
                Return Me.backField
            End Get
            Set(value As Byte())
                Me.backField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class Response
        Private statusField As String
        Private seqNoField As String
        Private tRNField As String
        Private submitterField As String
        Private reasonField As String
        Private debtorField As Debtor
        Private creditorField As Creditor
        Private amendatoryField As Boolean
        Private nonPaymentCertificateField As NonPaymentCertificate
        '''
        Public Property Status() As String
            Get
                Return Me.statusField
            End Get
            Set(value As String)
                Me.statusField = value
            End Set
        End Property
        '''
        Public Property SeqNo() As String
            Get
                Return Me.seqNoField
            End Get
            Set(value As String)
                Me.seqNoField = value
            End Set
        End Property
        '''
        Public Property TRN() As String
            Get
                Return Me.tRNField
            End Get
            Set(value As String)
                Me.tRNField = value
            End Set
        End Property
        '''
        Public Property Submitter() As String
            Get
                Return Me.submitterField
            End Get
            Set(value As String)
                Me.submitterField = value
            End Set
        End Property
        '''
        Public Property Reason() As String
            Get
                Return Me.reasonField
            End Get
            Set(value As String)
                Me.reasonField = value
            End Set
        End Property
        '''
        Public Property Debtor() As Debtor
            Get
                Return Me.debtorField
            End Get
            Set(value As Debtor)
                Me.debtorField = value
            End Set
        End Property
        '''
        Public Property Creditor() As Creditor
            Get
                Return Me.creditorField
            End Get
            Set(value As Creditor)
                Me.creditorField = value
            End Set
        End Property
        '''
        Public Property Amendatory() As Boolean
            Get
                Return Me.amendatoryField
            End Get
            Set(value As Boolean)
                Me.amendatoryField = value
            End Set
        End Property
        '''
        Public Property NonPaymentCertificate() As NonPaymentCertificate
            Get
                Return Me.nonPaymentCertificateField
            End Get
            Set(value As NonPaymentCertificate)
                Me.nonPaymentCertificateField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class NonPaymentCertificate
        Private chequeIssuerField As ChequeIssuer
        Private authorisedField() As Authorised
        Private otherAuthorisedField As Boolean
        '''
        Public Property ChequeIssuer() As ChequeIssuer
            Get
                Return Me.chequeIssuerField
            End Get
            Set(value As ChequeIssuer)
                Me.chequeIssuerField = value
            End Set
        End Property
        '''
        _
        Public Property Authorised() As Authorised()
            Get
                Return Me.authorisedField
            End Get
            Set(value As Authorised())
                Me.authorisedField = value
            End Set
        End Property
        '''
        Public Property OtherAuthorised() As Boolean
            Get
                Return Me.otherAuthorisedField
            End Get
            Set(value As Boolean)
                Me.otherAuthorisedField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class ChequeIssuer
        Private accountTypeField As String
        Private referToField As String
        Private nameField As String
        Private birthCertNumOrRegNumField As String
        Private birthDateOrRegDateField As String
        Private issueLocationOrRegLocationField As String
        Private locationCodeField As String
        Private officeCodeField As String
        Private fatherNameField As String
        Private nationalIDField As String
        Private postalCode1Field As String
        Private address1Field As String
        Private tel1Field As String
        Private postalCode2Field As String
        Private address2Field As String
        Private tel2Field As String
        Private curAccBalField As Decimal
        Private curAccBalFieldSpecified As Boolean
        Private onIssueDateAccBalField As System.Nullable(Of Decimal)
        Private isSettledField As Boolean
        '''
        Public Property AccountType() As String
            Get
                Return Me.accountTypeField
            End Get
            Set(value As String)
                Me.accountTypeField = value
            End Set
        End Property
        '''
        Public Property referTo() As String
            Get
                Return Me.referToField
            End Get
            Set(value As String)
                Me.referToField = value
            End Set
        End Property
        '''
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set(value As String)
                Me.nameField = value
            End Set
        End Property
        '''
        Public Property BirthCertNumOrRegNum() As String
            Get
                Return Me.birthCertNumOrRegNumField
            End Get
            Set(value As String)
                Me.birthCertNumOrRegNumField = value
            End Set
        End Property
        '''
        Public Property BirthDateOrRegDate() As String
            Get
                Return Me.birthDateOrRegDateField
            End Get
            Set(value As String)
                Me.birthDateOrRegDateField = value
            End Set
        End Property
        '''
        Public Property IssueLocationOrRegLocation() As String
            Get
                Return Me.issueLocationOrRegLocationField
            End Get
            Set(value As String)
                Me.issueLocationOrRegLocationField = value
            End Set
        End Property
        '''
        Public Property LocationCode() As String
            Get
                Return Me.locationCodeField
            End Get
            Set(value As String)
                Me.locationCodeField = value
            End Set
        End Property
        '''
        Public Property OfficeCode() As String
            Get
                Return Me.officeCodeField
            End Get
            Set(value As String)
                Me.officeCodeField = value
            End Set
        End Property
        '''
        Public Property FatherName() As String
            Get
                Return Me.fatherNameField
            End Get
            Set(value As String)
                Me.fatherNameField = value
            End Set
        End Property
        '''
        Public Property NationalID() As String
            Get
                Return Me.nationalIDField
            End Get
            Set(value As String)
                Me.nationalIDField = value
            End Set
        End Property
        '''
        Public Property PostalCode1() As String
            Get
                Return Me.postalCode1Field
            End Get
            Set(value As String)
                Me.postalCode1Field = value
            End Set
        End Property
        '''
        Public Property Address1() As String
            Get
                Return Me.address1Field
            End Get
            Set(value As String)
                Me.address1Field = value
            End Set
        End Property
        '''
        Public Property Tel1() As String
            Get
                Return Me.tel1Field
            End Get
            Set(value As String)
                Me.tel1Field = value
            End Set
        End Property
        '''
        Public Property PostalCode2() As String
            Get
                Return Me.postalCode2Field
            End Get
            Set(value As String)
                Me.postalCode2Field = value
            End Set
        End Property
        '''
        Public Property Address2() As String
            Get
                Return Me.address2Field
            End Get
            Set(value As String)
                Me.address2Field = value
            End Set
        End Property
        '''
        Public Property Tel2() As String
            Get
                Return Me.tel2Field
            End Get
            Set(value As String)
                Me.tel2Field = value
            End Set
        End Property
        '''
        Public Property CurAccBal() As Decimal
            Get
                Return Me.curAccBalField
            End Get
            Set(value As Decimal)
                Me.curAccBalField = value
            End Set
        End Property
        '''
        _
        Public Property CurAccBalSpecified() As Boolean
            Get
                Return Me.curAccBalFieldSpecified
            End Get
            Set(value As Boolean)
                Me.curAccBalFieldSpecified = value
            End Set
        End Property
        '''
        _
        Public Property OnIssueDateAccBal() As System.Nullable(Of Decimal)
            Get
                Return Me.onIssueDateAccBalField
            End Get
            Set(value As System.Nullable(Of Decimal))
                Me.onIssueDateAccBalField = value
            End Set
        End Property
        '''
        Public Property IsSettled() As Boolean
            Get
                Return Me.isSettledField
            End Get
            Set(value As Boolean)
                Me.isSettledField = value
            End Set
        End Property
    End Class
    '''
     _
    Partial Public Class Authorised
        Private fullNameField As String
        Private birthCertNumOrRegNumField As String
        Private birthDateOrRegDateField As String
        Private issueLocationOrRegLocationField As String
        Private locationCodeField As String
        Private officeCodeField As String
        Private fatherNameField As String
        Private nationalIDField As String
        Private postalCode1Field As String
        Private address1Field As String
        Private tel1Field As String
        Private referToField As String
        '''
        Public Property FullName() As String
            Get
                Return Me.fullNameField
            End Get
            Set(value As String)
                Me.fullNameField = value
            End Set
        End Property
        '''
        Public Property BirthCertNumOrRegNum() As String
            Get
                Return Me.birthCertNumOrRegNumField
            End Get
            Set(value As String)
                Me.birthCertNumOrRegNumField = value
            End Set
        End Property
        '''
        Public Property BirthDateOrRegDate() As String
            Get
                Return Me.birthDateOrRegDateField
            End Get
            Set(value As String)
                Me.birthDateOrRegDateField = value
            End Set
        End Property
        '''
        Public Property IssueLocationOrRegLocation() As String
            Get
                Return Me.issueLocationOrRegLocationField
            End Get
            Set(value As String)
                Me.issueLocationOrRegLocationField = value
            End Set
        End Property
        '''
        Public Property LocationCode() As String
            Get
                Return Me.locationCodeField
            End Get
            Set(value As String)
                Me.locationCodeField = value
            End Set
        End Property
        '''
        Public Property OfficeCode() As String
            Get
                Return Me.officeCodeField
            End Get
            Set(value As String)
                Me.officeCodeField = value
            End Set
        End Property
        '''
        Public Property FatherName() As String
            Get
                Return Me.fatherNameField
            End Get
            Set(value As String)
                Me.fatherNameField = value
            End Set
        End Property
        '''
        Public Property NationalID() As String
            Get
                Return Me.nationalIDField
            End Get
            Set(value As String)
                Me.nationalIDField = value
            End Set
        End Property
        '''
        Public Property PostalCode1() As String
            Get
                Return Me.postalCode1Field
            End Get
            Set(value As String)
                Me.postalCode1Field = value
            End Set
        End Property
        '''
        Public Property Address1() As String
            Get
                Return Me.address1Field
            End Get
            Set(value As String)
                Me.address1Field = value
            End Set
        End Property
        '''
        Public Property Tel1() As String
            Get
                Return Me.tel1Field
            End Get
            Set(value As String)
                Me.tel1Field = value
            End Set
        End Property
        '''
        Public Property referTo() As String
            Get
                Return Me.referToField
            End Get
            Set(value As String)
                Me.referToField = value
            End Set
        End Property
    End Class
End Namespace
''------------------------------------------------------------------------------
'' <auto-generated>
''     This code was generated by a tool.
''     Runtime Version:4.0.30319.42000
''
''     Changes to this file may cause incorrect behavior and will be lost if
''     the code is regenerated.
'' </auto-generated>
''------------------------------------------------------------------------------

'Option Strict Off
'Option Explicit On

'Imports System.Xml.Serialization

''
''This source code was auto-generated by xsd, Version=4.6.1055.0.
''
'Namespace com.cbi.chakavak.chequeSchema

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Cheque

'        Private headerField As Header

'        Private bodyField As Body

'        '''<remarks/>
'        Public Property Header() As Header
'            Get
'                Return Me.headerField
'            End Get
'            Set
'                Me.headerField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Body() As Body
'            Get
'                Return Me.bodyField
'            End Get
'            Set
'                Me.bodyField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Header

'        Private chequeIDField As String

'        Private depositDateField As String

'        Private settlementDateField As String

'        Private amountField As String

'        Private userNameField As String

'        '''<remarks/>
'        Public Property ChequeID() As String
'            Get
'                Return Me.chequeIDField
'            End Get
'            Set
'                Me.chequeIDField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property DepositDate() As String
'            Get
'                Return Me.depositDateField
'            End Get
'            Set
'                Me.depositDateField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property SettlementDate() As String
'            Get
'                Return Me.settlementDateField
'            End Get
'            Set
'                Me.settlementDateField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Amount() As String
'            Get
'                Return Me.amountField
'            End Get
'            Set
'                Me.amountField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property UserName() As String
'            Get
'                Return Me.userNameField
'            End Get
'            Set
'                Me.userNameField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Body

'        Private itemField As Object

'        '''<remarks/>
'        <System.Xml.Serialization.XmlElementAttribute("Acknowledge", GetType(Acknowledge)),  _
'         System.Xml.Serialization.XmlElementAttribute("Action", GetType(Action)),  _
'         System.Xml.Serialization.XmlElementAttribute("Request", GetType(Request)),  _
'         System.Xml.Serialization.XmlElementAttribute("Response", GetType(Response))>  _
'        Public Property Item() As Object
'            Get
'                Return Me.itemField
'            End Get
'            Set
'                Me.itemField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Acknowledge

'        Private tRNField As String

'        Private statusField As String

'        Private reasonField As String

'        Private debtorField As Debtor

'        Private creditorField As Creditor

'        '''<remarks/>
'        Public Property TRN() As String
'            Get
'                Return Me.tRNField
'            End Get
'            Set
'                Me.tRNField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Status() As String
'            Get
'                Return Me.statusField
'            End Get
'            Set
'                Me.statusField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Reason() As String
'            Get
'                Return Me.reasonField
'            End Get
'            Set
'                Me.reasonField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Debtor() As Debtor
'            Get
'                Return Me.debtorField
'            End Get
'            Set
'                Me.debtorField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Creditor() As Creditor
'            Get
'                Return Me.creditorField
'            End Get
'            Set
'                Me.creditorField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Debtor

'        Private nameField As String

'        Private iBANField As String

'        Private bICField As String

'        Private branchCodeField As String

'        '''<remarks/>
'        Public Property Name() As String
'            Get
'                Return Me.nameField
'            End Get
'            Set
'                Me.nameField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property IBAN() As String
'            Get
'                Return Me.iBANField
'            End Get
'            Set
'                Me.iBANField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property BIC() As String
'            Get
'                Return Me.bICField
'            End Get
'            Set
'                Me.bICField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property BranchCode() As String
'            Get
'                Return Me.branchCodeField
'            End Get
'            Set
'                Me.branchCodeField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Creditor

'        Private nameField As String

'        Private iBANField As String

'        Private nationalCodeField As String

'        Private bICField As String

'        Private branchCodeField As String

'        '''<remarks/>
'        Public Property Name() As String
'            Get
'                Return Me.nameField
'            End Get
'            Set
'                Me.nameField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property IBAN() As String
'            Get
'                Return Me.iBANField
'            End Get
'            Set
'                Me.iBANField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property NationalCode() As String
'            Get
'                Return Me.nationalCodeField
'            End Get
'            Set
'                Me.nationalCodeField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property BIC() As String
'            Get
'                Return Me.bICField
'            End Get
'            Set
'                Me.bICField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property BranchCode() As String
'            Get
'                Return Me.branchCodeField
'            End Get
'            Set
'                Me.branchCodeField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Action

'        Private seqNoField As String

'        Private eventField As String

'        Private debtorBicField As String

'        Private creditorBicField As String

'        Private tRNField As String

'        '''<remarks/>
'        Public Property SeqNo() As String
'            Get
'                Return Me.seqNoField
'            End Get
'            Set
'                Me.seqNoField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property [Event]() As String
'            Get
'                Return Me.eventField
'            End Get
'            Set
'                Me.eventField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property DebtorBic() As String
'            Get
'                Return Me.debtorBicField
'            End Get
'            Set
'                Me.debtorBicField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property CreditorBic() As String
'            Get
'                Return Me.creditorBicField
'            End Get
'            Set
'                Me.creditorBicField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property TRN() As String
'            Get
'                Return Me.tRNField
'            End Get
'            Set
'                Me.tRNField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Request

'        Private submitterField As String

'        Private priorityField As String

'        Private seqNoField As String

'        Private partialSettlementField As Boolean

'        Private partialSettlementFieldSpecified As Boolean

'        Private codedField As Boolean

'        Private prominentStampField As Boolean

'        Private regressiveField As String

'        Private instrIdField As String

'        Private debtorField As Debtor

'        Private creditorField As Creditor

'        Private requestDataField As RequestData

'        '''<remarks/>
'        Public Property Submitter() As String
'            Get
'                Return Me.submitterField
'            End Get
'            Set
'                Me.submitterField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Priority() As String
'            Get
'                Return Me.priorityField
'            End Get
'            Set
'                Me.priorityField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property SeqNo() As String
'            Get
'                Return Me.seqNoField
'            End Get
'            Set
'                Me.seqNoField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property PartialSettlement() As Boolean
'            Get
'                Return Me.partialSettlementField
'            End Get
'            Set
'                Me.partialSettlementField = value
'            End Set
'        End Property

'        '''<remarks/>
'        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
'        Public Property PartialSettlementSpecified() As Boolean
'            Get
'                Return Me.partialSettlementFieldSpecified
'            End Get
'            Set
'                Me.partialSettlementFieldSpecified = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Coded() As Boolean
'            Get
'                Return Me.codedField
'            End Get
'            Set
'                Me.codedField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property ProminentStamp() As Boolean
'            Get
'                Return Me.prominentStampField
'            End Get
'            Set
'                Me.prominentStampField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Regressive() As String
'            Get
'                Return Me.regressiveField
'            End Get
'            Set
'                Me.regressiveField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property InstrId() As String
'            Get
'                Return Me.instrIdField
'            End Get
'            Set
'                Me.instrIdField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Debtor() As Debtor
'            Get
'                Return Me.debtorField
'            End Get
'            Set
'                Me.debtorField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Creditor() As Creditor
'            Get
'                Return Me.creditorField
'            End Get
'            Set
'                Me.creditorField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property RequestData() As RequestData
'            Get
'                Return Me.requestDataField
'            End Get
'            Set
'                Me.requestDataField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class RequestData

'        Private frontField() As Byte

'        Private backField() As Byte

'        '''<remarks/>
'        <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")>  _
'        Public Property Front() As Byte()
'            Get
'                Return Me.frontField
'            End Get
'            Set
'                Me.frontField = value
'            End Set
'        End Property

'        '''<remarks/>
'        <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")>  _
'        Public Property Back() As Byte()
'            Get
'                Return Me.backField
'            End Get
'            Set
'                Me.backField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Response

'        Private statusField As String

'        Private seqNoField As String

'        Private tRNField As String

'        Private submitterField As String

'        Private reasonField As String

'        Private debtorField As Debtor

'        Private creditorField As Creditor

'        Private amendatoryField As Boolean

'        Private nonPaymentCertificateField As NonPaymentCertificate

'        '''<remarks/>
'        Public Property Status() As String
'            Get
'                Return Me.statusField
'            End Get
'            Set
'                Me.statusField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property SeqNo() As String
'            Get
'                Return Me.seqNoField
'            End Get
'            Set
'                Me.seqNoField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property TRN() As String
'            Get
'                Return Me.tRNField
'            End Get
'            Set
'                Me.tRNField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Submitter() As String
'            Get
'                Return Me.submitterField
'            End Get
'            Set
'                Me.submitterField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Reason() As String
'            Get
'                Return Me.reasonField
'            End Get
'            Set
'                Me.reasonField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Debtor() As Debtor
'            Get
'                Return Me.debtorField
'            End Get
'            Set
'                Me.debtorField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Creditor() As Creditor
'            Get
'                Return Me.creditorField
'            End Get
'            Set
'                Me.creditorField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Amendatory() As Boolean
'            Get
'                Return Me.amendatoryField
'            End Get
'            Set
'                Me.amendatoryField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property NonPaymentCertificate() As NonPaymentCertificate
'            Get
'                Return Me.nonPaymentCertificateField
'            End Get
'            Set
'                Me.nonPaymentCertificateField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class NonPaymentCertificate

'        Private chequeIssuerField As ChequeIssuer

'        Private authorisedField() As Authorised

'        Private otherAuthorisedField As Boolean

'        '''<remarks/>
'        Public Property ChequeIssuer() As ChequeIssuer
'            Get
'                Return Me.chequeIssuerField
'            End Get
'            Set
'                Me.chequeIssuerField = value
'            End Set
'        End Property

'        '''<remarks/>
'        <System.Xml.Serialization.XmlElementAttribute("Authorised")>  _
'        Public Property Authorised() As Authorised()
'            Get
'                Return Me.authorisedField
'            End Get
'            Set
'                Me.authorisedField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property OtherAuthorised() As Boolean
'            Get
'                Return Me.otherAuthorisedField
'            End Get
'            Set
'                Me.otherAuthorisedField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class ChequeIssuer

'        Private accountTypeField As String

'        Private referToField As String

'        Private nameField As String

'        Private birthCertNumOrRegNumField As String

'        Private birthDateOrRegDateField As String

'        Private issueLocationOrRegLocationField As String

'        Private locationCodeField As String

'        Private officeCodeField As String

'        Private fatherNameField As String

'        Private nationalIDField As String

'        Private postalCode1Field As String

'        Private address1Field As String

'        Private tel1Field As String

'        Private postalCode2Field As String

'        Private address2Field As String

'        Private tel2Field As String

'        Private curAccBalField As Decimal

'        Private curAccBalFieldSpecified As Boolean

'        Private onIssueDateAccBalField As System.Nullable(Of Decimal)

'        Private isSettledField As Boolean

'        '''<remarks/>
'        Public Property AccountType() As String
'            Get
'                Return Me.accountTypeField
'            End Get
'            Set
'                Me.accountTypeField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property referTo() As String
'            Get
'                Return Me.referToField
'            End Get
'            Set
'                Me.referToField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Name() As String
'            Get
'                Return Me.nameField
'            End Get
'            Set
'                Me.nameField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property BirthCertNumOrRegNum() As String
'            Get
'                Return Me.birthCertNumOrRegNumField
'            End Get
'            Set
'                Me.birthCertNumOrRegNumField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property BirthDateOrRegDate() As String
'            Get
'                Return Me.birthDateOrRegDateField
'            End Get
'            Set
'                Me.birthDateOrRegDateField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property IssueLocationOrRegLocation() As String
'            Get
'                Return Me.issueLocationOrRegLocationField
'            End Get
'            Set
'                Me.issueLocationOrRegLocationField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property LocationCode() As String
'            Get
'                Return Me.locationCodeField
'            End Get
'            Set
'                Me.locationCodeField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property OfficeCode() As String
'            Get
'                Return Me.officeCodeField
'            End Get
'            Set
'                Me.officeCodeField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property FatherName() As String
'            Get
'                Return Me.fatherNameField
'            End Get
'            Set
'                Me.fatherNameField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property NationalID() As String
'            Get
'                Return Me.nationalIDField
'            End Get
'            Set
'                Me.nationalIDField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property PostalCode1() As String
'            Get
'                Return Me.postalCode1Field
'            End Get
'            Set
'                Me.postalCode1Field = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Address1() As String
'            Get
'                Return Me.address1Field
'            End Get
'            Set
'                Me.address1Field = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Tel1() As String
'            Get
'                Return Me.tel1Field
'            End Get
'            Set
'                Me.tel1Field = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property PostalCode2() As String
'            Get
'                Return Me.postalCode2Field
'            End Get
'            Set
'                Me.postalCode2Field = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Address2() As String
'            Get
'                Return Me.address2Field
'            End Get
'            Set
'                Me.address2Field = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Tel2() As String
'            Get
'                Return Me.tel2Field
'            End Get
'            Set
'                Me.tel2Field = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property CurAccBal() As Decimal
'            Get
'                Return Me.curAccBalField
'            End Get
'            Set
'                Me.curAccBalField = value
'            End Set
'        End Property

'        '''<remarks/>
'        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
'        Public Property CurAccBalSpecified() As Boolean
'            Get
'                Return Me.curAccBalFieldSpecified
'            End Get
'            Set
'                Me.curAccBalFieldSpecified = value
'            End Set
'        End Property

'        '''<remarks/>
'        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
'        Public Property OnIssueDateAccBal() As System.Nullable(Of Decimal)
'            Get
'                Return Me.onIssueDateAccBalField
'            End Get
'            Set
'                Me.onIssueDateAccBalField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property IsSettled() As Boolean
'            Get
'                Return Me.isSettledField
'            End Get
'            Set
'                Me.isSettledField = value
'            End Set
'        End Property
'    End Class

'    '''<remarks/>
'    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0"),  _
'     System.SerializableAttribute(),  _
'     System.Diagnostics.DebuggerStepThroughAttribute(),  _
'     System.ComponentModel.DesignerCategoryAttribute("code"),  _
'     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
'     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
'    Partial Public Class Authorised

'        Private fullNameField As String

'        Private birthCertNumOrRegNumField As String

'        Private birthDateOrRegDateField As String

'        Private issueLocationOrRegLocationField As String

'        Private locationCodeField As String

'        Private officeCodeField As String

'        Private fatherNameField As String

'        Private nationalIDField As String

'        Private postalCode1Field As String

'        Private address1Field As String

'        Private tel1Field As String

'        Private referToField As String

'        '''<remarks/>
'        Public Property FullName() As String
'            Get
'                Return Me.fullNameField
'            End Get
'            Set
'                Me.fullNameField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property BirthCertNumOrRegNum() As String
'            Get
'                Return Me.birthCertNumOrRegNumField
'            End Get
'            Set
'                Me.birthCertNumOrRegNumField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property BirthDateOrRegDate() As String
'            Get
'                Return Me.birthDateOrRegDateField
'            End Get
'            Set
'                Me.birthDateOrRegDateField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property IssueLocationOrRegLocation() As String
'            Get
'                Return Me.issueLocationOrRegLocationField
'            End Get
'            Set
'                Me.issueLocationOrRegLocationField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property LocationCode() As String
'            Get
'                Return Me.locationCodeField
'            End Get
'            Set
'                Me.locationCodeField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property OfficeCode() As String
'            Get
'                Return Me.officeCodeField
'            End Get
'            Set
'                Me.officeCodeField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property FatherName() As String
'            Get
'                Return Me.fatherNameField
'            End Get
'            Set
'                Me.fatherNameField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property NationalID() As String
'            Get
'                Return Me.nationalIDField
'            End Get
'            Set
'                Me.nationalIDField = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property PostalCode1() As String
'            Get
'                Return Me.postalCode1Field
'            End Get
'            Set
'                Me.postalCode1Field = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Address1() As String
'            Get
'                Return Me.address1Field
'            End Get
'            Set
'                Me.address1Field = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property Tel1() As String
'            Get
'                Return Me.tel1Field
'            End Get
'            Set
'                Me.tel1Field = value
'            End Set
'        End Property

'        '''<remarks/>
'        Public Property referTo() As String
'            Get
'                Return Me.referToField
'            End Get
'            Set
'                Me.referToField = value
'            End Set
'        End Property
'    End Class
'End Namespace
