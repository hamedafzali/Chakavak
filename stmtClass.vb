'------------------------------------------------------------------------------
'THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
'FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
'DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
'ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
'------------------------------------------------------------------------------


Namespace com.cbi.chakavak.stmt
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=true)>  _
   Partial Public Class Hal_CurrencyAndAmount
      Private ccyField As String
      Private valueField As Decimal
      '''<remarks/>
      <System.Xml.Serialization.XmlAttributeAttribute()>  _
      Public Property Ccy() As String
         Get
            Return Me.ccyField
         End Get
         Set
            Me.ccyField = value
         End Set
      End Property
      '''<remarks/>
      <System.Xml.Serialization.XmlTextAttribute()>  _
      Public Property Value() As Decimal
         Get
            Return Me.valueField
         End Get
         Set
            Me.valueField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=true)>  _
   Partial Public Class Hal_Balance_CurrencyAndAmount
      Private ccyField As String
      Private valueField As Decimal
      '''<remarks/>
      <System.Xml.Serialization.XmlAttributeAttribute()>  _
      Public Property Ccy() As String
         Get
            Return Me.ccyField
         End Get
         Set
            Me.ccyField = value
         End Set
      End Property
      '''<remarks/>
      <System.Xml.Serialization.XmlTextAttribute()>  _
      Public Property Value() As Decimal
         Get
            Return Me.valueField
         End Get
         Set
            Me.valueField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
   Public Enum CreditorDebtor
      '''<remarks/>
      CRDT
      '''<remarks/>
      DBIT
   End Enum
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
   Public Enum TransactionCode
      '''<remarks/>
      <System.Xml.Serialization.XmlEnumAttribute("pacs.008.001.01")>  _
      pacs00800101
      '''<remarks/>
      <System.Xml.Serialization.XmlEnumAttribute("pacs.004.001.01")>  _
      pacs00400101
   End Enum
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
   Public Enum ReversalIndicator
      '''<remarks/>
      [false]
      '''<remarks/>
      [true]
   End Enum
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
   Public Enum LastPgIndType
      '''<remarks/>
      [true]
      '''<remarks/>
      [false]
   End Enum
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
   Public Enum Status
      '''<remarks/>
      BOOK
   End Enum
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
   Public Enum BalanceType9Code
      '''<remarks/>
      CLBD
   End Enum
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
   Partial Public Class Document
      Private bkToCstmrStmtV01Field As DocumentBkToCstmrStmtV01
      '''<remarks/>
      Public Property BkToCstmrStmtV01() As DocumentBkToCstmrStmtV01
         Get
            Return Me.bkToCstmrStmtV01Field
         End Get
         Set
            Me.bkToCstmrStmtV01Field = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01
      Private grpHdrField As DocumentBkToCstmrStmtV01GrpHdr
      Private stmtField() As DocumentBkToCstmrStmtV01Stmt
      '''<remarks/>
      Public Property GrpHdr() As DocumentBkToCstmrStmtV01GrpHdr
         Get
            Return Me.grpHdrField
         End Get
         Set
            Me.grpHdrField = value
         End Set
      End Property
      '''<remarks/>
      <System.Xml.Serialization.XmlElementAttribute("Stmt")>  _
      Public Property Stmt() As DocumentBkToCstmrStmtV01Stmt()
         Get
            Return Me.stmtField
         End Get
         Set
            Me.stmtField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01GrpHdr
      Private msgIdField As String
      Private creDtTmField As String
      Private msgPgntnField As DocumentBkToCstmrStmtV01GrpHdrMsgPgntn
      Private addtlInfField As String
      '''<remarks/>
      Public Property MsgId() As String
         Get
            Return Me.msgIdField
         End Get
         Set
            Me.msgIdField = value
         End Set
      End Property
      '''<remarks/>
      Public Property CreDtTm() As String
         Get
            Return Me.creDtTmField
         End Get
         Set
            Me.creDtTmField = value
         End Set
      End Property
      '''<remarks/>
      Public Property MsgPgntn() As DocumentBkToCstmrStmtV01GrpHdrMsgPgntn
         Get
            Return Me.msgPgntnField
         End Get
         Set
            Me.msgPgntnField = value
         End Set
      End Property
      '''<remarks/>
      Public Property AddtlInf() As String
         Get
            Return Me.addtlInfField
         End Get
         Set
            Me.addtlInfField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01GrpHdrMsgPgntn
      Private pgNbField As String
      Private lastPgIndField As LastPgIndType
      '''<remarks/>
      <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
      Public Property PgNb() As String
         Get
            Return Me.pgNbField
         End Get
         Set
            Me.pgNbField = value
         End Set
      End Property
      '''<remarks/>
      Public Property LastPgInd() As LastPgIndType
         Get
            Return Me.lastPgIndField
         End Get
         Set
            Me.lastPgIndField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01Stmt
      Private idField As String
      Private creDtTmField As String
      Private acctField As DocumentBkToCstmrStmtV01StmtAcct
      Private balField As DocumentBkToCstmrStmtV01StmtBal
      Private ntryField() As DocumentBkToCstmrStmtV01StmtNtry
      '''<remarks/>
      Public Property Id() As String
         Get
            Return Me.idField
         End Get
         Set
            Me.idField = value
         End Set
      End Property
      '''<remarks/>
      Public Property CreDtTm() As String
         Get
            Return Me.creDtTmField
         End Get
         Set
            Me.creDtTmField = value
         End Set
      End Property
      '''<remarks/>
      Public Property Acct() As DocumentBkToCstmrStmtV01StmtAcct
         Get
            Return Me.acctField
         End Get
         Set
            Me.acctField = value
         End Set
      End Property
      '''<remarks/>
      Public Property Bal() As DocumentBkToCstmrStmtV01StmtBal
         Get
            Return Me.balField
         End Get
         Set
            Me.balField = value
         End Set
      End Property
      '''<remarks/>
      <System.Xml.Serialization.XmlElementAttribute("Ntry")>  _
      Public Property Ntry() As DocumentBkToCstmrStmtV01StmtNtry()
         Get
            Return Me.ntryField
         End Get
         Set
            Me.ntryField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtAcct
      Private idField As DocumentBkToCstmrStmtV01StmtAcctID
      Private svcrField As DocumentBkToCstmrStmtV01StmtAcctSvcr
      '''<remarks/>
      Public Property Id() As DocumentBkToCstmrStmtV01StmtAcctID
         Get
            Return Me.idField
         End Get
         Set
            Me.idField = value
         End Set
      End Property
      '''<remarks/>
      Public Property Svcr() As DocumentBkToCstmrStmtV01StmtAcctSvcr
         Get
            Return Me.svcrField
         End Get
         Set
            Me.svcrField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtAcctID
      Private prtryAcctField As DocumentBkToCstmrStmtV01StmtAcctIDPrtryAcct
      '''<remarks/>
      Public Property PrtryAcct() As DocumentBkToCstmrStmtV01StmtAcctIDPrtryAcct
         Get
            Return Me.prtryAcctField
         End Get
         Set
            Me.prtryAcctField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtAcctIDPrtryAcct
      Private idField As String
      '''<remarks/>
      Public Property Id() As String
         Get
            Return Me.idField
         End Get
         Set
            Me.idField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtAcctSvcr
      Private finInstnIdField As DocumentBkToCstmrStmtV01StmtAcctSvcrFinInstnId
      '''<remarks/>
      Public Property FinInstnId() As DocumentBkToCstmrStmtV01StmtAcctSvcrFinInstnId
         Get
            Return Me.finInstnIdField
         End Get
         Set
            Me.finInstnIdField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtAcctSvcrFinInstnId
      Private prtryIdField As DocumentBkToCstmrStmtV01StmtAcctSvcrFinInstnIdPrtryId
      '''<remarks/>
      Public Property PrtryId() As DocumentBkToCstmrStmtV01StmtAcctSvcrFinInstnIdPrtryId
         Get
            Return Me.prtryIdField
         End Get
         Set
            Me.prtryIdField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtAcctSvcrFinInstnIdPrtryId
      Private idField As String
      '''<remarks/>
      Public Property Id() As String
         Get
            Return Me.idField
         End Get
         Set
            Me.idField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtBal
      Private tpField As DocumentBkToCstmrStmtV01StmtBalTP
      Private amtField As Hal_Balance_CurrencyAndAmount
      Private cdtDbtIndField As CreditorDebtor
      Private dtField As DocumentBkToCstmrStmtV01StmtBalDT
      '''<remarks/>
      Public Property Tp() As DocumentBkToCstmrStmtV01StmtBalTP
         Get
            Return Me.tpField
         End Get
         Set
            Me.tpField = value
         End Set
      End Property
      '''<remarks/>
      Public Property Amt() As Hal_Balance_CurrencyAndAmount
         Get
            Return Me.amtField
         End Get
         Set
            Me.amtField = value
         End Set
      End Property
      '''<remarks/>
      Public Property CdtDbtInd() As CreditorDebtor
         Get
            Return Me.cdtDbtIndField
         End Get
         Set
            Me.cdtDbtIndField = value
         End Set
      End Property
      '''<remarks/>
      Public Property Dt() As DocumentBkToCstmrStmtV01StmtBalDT
         Get
            Return Me.dtField
         End Get
         Set
            Me.dtField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtBalTP
      Private cdField As BalanceType9Code
      '''<remarks/>
      Public Property Cd() As BalanceType9Code
         Get
            Return Me.cdField
         End Get
         Set
            Me.cdField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtBalDT
      Private dtTmField As String
      '''<remarks/>
      Public Property DtTm() As String
         Get
            Return Me.dtTmField
         End Get
         Set
            Me.dtTmField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtry
      Private amtField As Hal_CurrencyAndAmount
      Private cdtDbtIndField As CreditorDebtor
      Private rvslIndField As ReversalIndicator
      Private stsField As Status
      Private bookgDtField As DocumentBkToCstmrStmtV01StmtNtryBookgDt
      Private valDtField As DocumentBkToCstmrStmtV01StmtNtryValDt
      Private bkTxCdField As DocumentBkToCstmrStmtV01StmtNtryBkTxCd
      Private txDtlsField As DocumentBkToCstmrStmtV01StmtNtryTxDtls
      '''<remarks/>
      Public Property Amt() As Hal_CurrencyAndAmount
         Get
            Return Me.amtField
         End Get
         Set
            Me.amtField = value
         End Set
      End Property
      '''<remarks/>
      Public Property CdtDbtInd() As CreditorDebtor
         Get
            Return Me.cdtDbtIndField
         End Get
         Set
            Me.cdtDbtIndField = value
         End Set
      End Property
      '''<remarks/>
      Public Property RvslInd() As ReversalIndicator
         Get
            Return Me.rvslIndField
         End Get
         Set
            Me.rvslIndField = value
         End Set
      End Property
      '''<remarks/>
      Public Property Sts() As Status
         Get
            Return Me.stsField
         End Get
         Set
            Me.stsField = value
         End Set
      End Property
      '''<remarks/>
      Public Property BookgDt() As DocumentBkToCstmrStmtV01StmtNtryBookgDt
         Get
            Return Me.bookgDtField
         End Get
         Set
            Me.bookgDtField = value
         End Set
      End Property
      '''<remarks/>
      Public Property ValDt() As DocumentBkToCstmrStmtV01StmtNtryValDt
         Get
            Return Me.valDtField
         End Get
         Set
            Me.valDtField = value
         End Set
      End Property
      '''<remarks/>
      Public Property BkTxCd() As DocumentBkToCstmrStmtV01StmtNtryBkTxCd
         Get
            Return Me.bkTxCdField
         End Get
         Set
            Me.bkTxCdField = value
         End Set
      End Property
      '''<remarks/>
      Public Property TxDtls() As DocumentBkToCstmrStmtV01StmtNtryTxDtls
         Get
            Return Me.txDtlsField
         End Get
         Set
            Me.txDtlsField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryBookgDt
      Private dtTmField As String
      '''<remarks/>
      Public Property DtTm() As String
         Get
            Return Me.dtTmField
         End Get
         Set
            Me.dtTmField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryValDt
      Private dtTmField As String
      '''<remarks/>
      Public Property DtTm() As String
         Get
            Return Me.dtTmField
         End Get
         Set
            Me.dtTmField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryBkTxCd
      Private prtryField As DocumentBkToCstmrStmtV01StmtNtryBkTxCdPrtry
      '''<remarks/>
      Public Property Prtry() As DocumentBkToCstmrStmtV01StmtNtryBkTxCdPrtry
         Get
            Return Me.prtryField
         End Get
         Set
            Me.prtryField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryBkTxCdPrtry
      Private cdField As TransactionCode
      '''<remarks/>
      Public Property Cd() As TransactionCode
         Get
            Return Me.cdField
         End Get
         Set
            Me.cdField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtls
      Private refsField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRefs
      Private rltdPtiesField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPties
      Private rltdAgtsField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgts
      '''<remarks/>
      Public Property Refs() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRefs
         Get
            Return Me.refsField
         End Get
         Set
            Me.refsField = value
         End Set
      End Property
      '''<remarks/>
      Public Property RltdPties() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPties
         Get
            Return Me.rltdPtiesField
         End Get
         Set
            Me.rltdPtiesField = value
         End Set
      End Property
      '''<remarks/>
      Public Property RltdAgts() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgts
         Get
            Return Me.rltdAgtsField
         End Get
         Set
            Me.rltdAgtsField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRefs
      Private endToEndIdField As String
      Private chqNbField As String
      Private instrIdField As String
      '''<remarks/>
      Public Property EndToEndId() As String
         Get
            Return Me.endToEndIdField
         End Get
         Set
            Me.endToEndIdField = value
         End Set
      End Property
      '''<remarks/>
      Public Property ChqNb() As String
         Get
            Return Me.chqNbField
         End Get
         Set
            Me.chqNbField = value
         End Set
      End Property
      '''<remarks/>
      Public Property InstrId() As String
         Get
            Return Me.instrIdField
         End Get
         Set
            Me.instrIdField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPties
      Private dbtrField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesDbtr
      Private dbtrAcctField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesDbtrAcct
      Private cdtrField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtr
      Private cdtrAcctField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrAcct
      '''<remarks/>
      Public Property Dbtr() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesDbtr
         Get
            Return Me.dbtrField
         End Get
         Set
            Me.dbtrField = value
         End Set
      End Property
      '''<remarks/>
      Public Property DbtrAcct() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesDbtrAcct
         Get
            Return Me.dbtrAcctField
         End Get
         Set
            Me.dbtrAcctField = value
         End Set
      End Property
      '''<remarks/>
      Public Property Cdtr() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtr
         Get
            Return Me.cdtrField
         End Get
         Set
            Me.cdtrField = value
         End Set
      End Property
      '''<remarks/>
      Public Property CdtrAcct() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrAcct
         Get
            Return Me.cdtrAcctField
         End Get
         Set
            Me.cdtrAcctField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesDbtr
      Private nmField As String
      '''<remarks/>
      Public Property Nm() As String
         Get
            Return Me.nmField
         End Get
         Set
            Me.nmField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesDbtrAcct
      Private idField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesDbtrAcctID
      '''<remarks/>
      Public Property Id() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesDbtrAcctID
         Get
            Return Me.idField
         End Get
         Set
            Me.idField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesDbtrAcctID
      Private iBANField As String
      '''<remarks/>
      Public Property IBAN() As String
         Get
            Return Me.iBANField
         End Get
         Set
            Me.iBANField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtr
      Private nmField As String
      Private idField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrID
      '''<remarks/>
      Public Property Nm() As String
         Get
            Return Me.nmField
         End Get
         Set
            Me.nmField = value
         End Set
      End Property
      '''<remarks/>
      Public Property Id() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrID
         Get
            Return Me.idField
         End Get
         Set
            Me.idField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrID
      Private prvtIdField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrIDPrvtId
      '''<remarks/>
      Public Property PrvtId() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrIDPrvtId
         Get
            Return Me.prvtIdField
         End Get
         Set
            Me.prvtIdField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrIDPrvtId
      Private idntyCardNbField As String
      '''<remarks/>
      Public Property IdntyCardNb() As String
         Get
            Return Me.idntyCardNbField
         End Get
         Set
            Me.idntyCardNbField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrAcct
      Private idField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrAcctID
      '''<remarks/>
      Public Property Id() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrAcctID
         Get
            Return Me.idField
         End Get
         Set
            Me.idField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdPtiesCdtrAcctID
      Private iBANField As String
      '''<remarks/>
      Public Property IBAN() As String
         Get
            Return Me.iBANField
         End Get
         Set
            Me.iBANField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgts
      Private cdtrAgtField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsCdtrAgt
      Private dbtrAgtField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsDbtrAgt
      '''<remarks/>
      Public Property CdtrAgt() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsCdtrAgt
         Get
            Return Me.cdtrAgtField
         End Get
         Set
            Me.cdtrAgtField = value
         End Set
      End Property
      '''<remarks/>
      Public Property DbtrAgt() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsDbtrAgt
         Get
            Return Me.dbtrAgtField
         End Get
         Set
            Me.dbtrAgtField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsCdtrAgt
      Private finInstnIdField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsCdtrAgtFinInstnId
      Private brnchIdField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsCdtrAgtBrnchId
      '''<remarks/>
      Public Property FinInstnId() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsCdtrAgtFinInstnId
         Get
            Return Me.finInstnIdField
         End Get
         Set
            Me.finInstnIdField = value
         End Set
      End Property
      '''<remarks/>
      Public Property BrnchId() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsCdtrAgtBrnchId
         Get
            Return Me.brnchIdField
         End Get
         Set
            Me.brnchIdField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsCdtrAgtFinInstnId
      Private bICField As String
      '''<remarks/>
      Public Property BIC() As String
         Get
            Return Me.bICField
         End Get
         Set
            Me.bICField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsCdtrAgtBrnchId
      Private idField As String
      '''<remarks/>
      Public Property Id() As String
         Get
            Return Me.idField
         End Get
         Set
            Me.idField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsDbtrAgt
      Private finInstnIdField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsDbtrAgtFinInstnId
      Private brnchIdField As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsDbtrAgtBrnchId
      '''<remarks/>
      Public Property FinInstnId() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsDbtrAgtFinInstnId
         Get
            Return Me.finInstnIdField
         End Get
         Set
            Me.finInstnIdField = value
         End Set
      End Property
      '''<remarks/>
      Public Property BrnchId() As DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsDbtrAgtBrnchId
         Get
            Return Me.brnchIdField
         End Get
         Set
            Me.brnchIdField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsDbtrAgtFinInstnId
      Private bICField As String
      '''<remarks/>
      Public Property BIC() As String
         Get
            Return Me.bICField
         End Get
         Set
            Me.bICField = value
         End Set
      End Property
   End Class
   '''<remarks/>
   <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"),  _
    System.SerializableAttribute(),  _
    System.Diagnostics.DebuggerStepThroughAttribute(),  _
    System.ComponentModel.DesignerCategoryAttribute("code"),  _
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
   Partial Public Class DocumentBkToCstmrStmtV01StmtNtryTxDtlsRltdAgtsDbtrAgtBrnchId
      Private idField As String
      '''<remarks/>
      Public Property Id() As String
         Get
            Return Me.idField
         End Get
         Set
            Me.idField = value
         End Set
      End Property
   End Class
End Namespace
