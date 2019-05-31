'------------------------------------------------------------------------------
'THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
'FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
'DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
'ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
'------------------------------------------------------------------------------


Namespace com.cbi.chakavak.InformationSchema
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)> _
    Partial Public Class Information
        Private headerField As Header
        Private bodyField As Body
        '''<remarks/>
        Public Property Header() As Header
            Get
                Return Me.headerField
            End Get
            Set(value As Header)
                Me.headerField = Value
            End Set
        End Property
        '''<remarks/>
        Public Property Body() As Body
            Get
                Return Me.bodyField
            End Get
            Set(value As Body)
                Me.bodyField = Value
            End Set
        End Property
    End Class
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)> _
    Partial Public Class Header
        Private publisherField As String
        Private subscriberField As String
        Private informationTypeField As String
        '''<remarks/>
        Public Property Publisher() As String
            Get
                Return Me.publisherField
            End Get
            Set(value As String)
                Me.publisherField = Value
            End Set
        End Property
        '''<remarks/>
        Public Property Subscriber() As String
            Get
                Return Me.subscriberField
            End Get
            Set(value As String)
                Me.subscriberField = Value
            End Set
        End Property
        '''<remarks/>
        Public Property InformationType() As String
            Get
                Return Me.informationTypeField
            End Get
            Set(value As String)
                Me.informationTypeField = Value
            End Set
        End Property
    End Class
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)> _
    Partial Public Class Body
        Private itemField As String
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("InformationContent")> _
        Public Property Item() As String
            Get
                Return Me.itemField
            End Get
            Set(value As String)
                Me.itemField = Value
            End Set
        End Property
    End Class
End Namespace
