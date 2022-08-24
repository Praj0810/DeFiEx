Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts
Imports System.Threading
Namespace DEFIex.Contracts.LiquidityPool.ContractDefinition

    
    
    Public Partial Class LiquidityPoolDeployment
     Inherits LiquidityPoolDeploymentBase
    
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
    
    End Class

    Public Class LiquidityPoolDeploymentBase 
            Inherits ContractDeploymentMessage
        
        Public Shared DEFAULT_BYTECODE As String = "608060405234801561001057600080fd5b5061001a3361001f565b61006f565b600080546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b610f138061007e6000396000f3fe60806040526004361061009c5760003560e01c80638da5cb5b116100645780638da5cb5b14610138578063d004f0f71461016a578063e48575d41461017d578063f2fde38b1461019d578063f363393b146101bd578063f42ebbe0146101dd57600080fd5b80630902f1ac146100a15780634bb12dfb146100ce578063573d0eef146100e3578063639f59c614610103578063715018a614610123575b600080fd5b3480156100ad57600080fd5b50600354600454604080519283526020830191909152015b60405180910390f35b6100e16100dc366004610d8d565b6101fd565b005b3480156100ef57600080fd5b506100e16100fe366004610dbd565b610383565b34801561010f57600080fd5b506100e161011e366004610dbd565b6103fb565b34801561012f57600080fd5b506100e161074a565b34801561014457600080fd5b506000546001600160a01b03165b6040516001600160a01b0390911681526020016100c5565b6100e1610178366004610dda565b61075e565b34801561018957600080fd5b50600254610152906001600160a01b031681565b3480156101a957600080fd5b506100e16101b8366004610dbd565b6109db565b3480156101c957600080fd5b50600154610152906001600160a01b031681565b3480156101e957600080fd5b506100e16101f8366004610dbd565b610a54565b6001546040516370a0823160e01b81526001600160a01b03838116600483015260009283929116906370a082319060240160206040518083038186803b15801561024657600080fd5b505afa15801561025a573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061027e9190610e06565b90503481156102c5576003546102be906102988484610e35565b6102a29190610e6a565b6004546102af8589610e35565b6102b99190610e6a565b610ac7565b92506102da565b6102d76102d28683610e35565b610adf565b92505b6001546040516340c10f1960e01b81526001600160a01b03868116600483015260248201869052909116906340c10f1990604401600060405180830381600087803b15801561032857600080fd5b505af115801561033c573d6000803e3d6000fd5b50506040516001600160a01b03871692507f849592496cf4faf2b1ca61853227d943c7787bdf2634d1654558e93d26ef1f8d9150600090a261037c610c4a565b5050505050565b61038b610cce565b6002546001600160a01b0316156103d95760405162461bcd60e51b815260206004820152600d60248201526c536574206f6e6c79206f6e636560981b60448201526064015b60405180910390fd5b600280546001600160a01b0319166001600160a01b0392909216919091179055565b6001546040516370a0823160e01b81526001600160a01b03838116600483015260009216906370a082319060240160206040518083038186803b15801561044157600080fd5b505afa158015610455573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906104799190610e06565b9050806104be5760405162461bcd60e51b81526020600482015260136024820152724e4f20746f6b656e7320417661696c61626c6560681b60448201526064016103d0565b600154604080516318160ddd60e01b815290516000926001600160a01b0316916318160ddd916004808301926020929190829003018186803b15801561050357600080fd5b505afa158015610517573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061053b9190610e06565b90506000818360035461054e9190610e35565b6105589190610e6a565b90506000828460045461056b9190610e35565b6105759190610e6a565b600154604051632770a7eb60e21b81526001600160a01b03888116600483015260248201889052929350911690639dc29fac90604401600060405180830381600087803b1580156105c557600080fd5b505af11580156105d9573d6000803e3d6000fd5b505050506000856001600160a01b03168360405160006040518083038185875af1925050503d806000811461062a576040519150601f19603f3d011682016040523d82523d6000602084013e61062f565b606091505b505060025460405163a9059cbb60e01b81526001600160a01b038981166004830152602482018690529293506000929091169063a9059cbb90604401602060405180830381600087803b15801561068557600080fd5b505af1158015610699573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906106bd9190610e8c565b90508180156106c95750805b6107055760405162461bcd60e51b815260206004820152600d60248201526c151c985b9cd9995c8819985a5b609a1b60448201526064016103d0565b6040516001600160a01b038816907f585628be90651057c5f706831b04eded021d87f2f5814f35c6c0232a5a99629b90600090a2610741610c4a565b50505050505050565b610752610cce565b61075c6000610d28565b565b60006004546003546107709190610e35565b90506000346108d4576002546040516370a0823160e01b81523060048201526000916001600160a01b0316906370a082319060240160206040518083038186803b1580156107bd57600080fd5b505afa1580156107d1573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906107f59190610e06565b90506000846004546108079190610eae565b905081811461084d5760405162461bcd60e51b81526020600482015260126024820152712737903a3930b739b332b9103430b83832b760711b60448201526064016103d0565b60006108598386610e6a565b9050806003546108699190610ec6565b93506000876001600160a01b03168560405160006040518083038185875af1925050503d80600081146108b8576040519150601f19603f3d011682016040523d82523d6000602084013e6108bd565b606091505b50509050806108cb57600080fd5b50505050610989565b6000346003546108e49190610eae565b6108ee9084610e6a565b9050806004546108fe9190610ec6565b60025460405163a9059cbb60e01b81526001600160a01b0388811660048301526024820184905292945091169063a9059cbb90604401602060405180830381600087803b15801561094e57600080fd5b505af1158015610962573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906109869190610e8c565b50505b60408051348152602081018590526001600160a01b038616917f7c0ab2086e70eee23a2a6ef5f86a200cb144b64896b8af0e3e73e8bda1889060910160405180910390a26109d5610c4a565b50505050565b6109e3610cce565b6001600160a01b038116610a485760405162461bcd60e51b815260206004820152602660248201527f4f776e61626c653a206e6577206f776e657220697320746865207a65726f206160448201526564647265737360d01b60648201526084016103d0565b610a5181610d28565b50565b610a5c610cce565b6001546001600160a01b031615610aa55760405162461bcd60e51b815260206004820152600d60248201526c736574206f6e6c79206f6e636560981b60448201526064016103d0565b600180546001600160a01b0319166001600160a01b0392909216919091179055565b6000818310610ad65781610ad8565b825b9392505050565b600081610aee57506000919050565b600182608081901c15610b065760409190911b9060801c5b604081901c15610b1b5760209190911b9060401c5b602081901c15610b305760109190911b9060201c5b601081901c15610b455760089190911b9060101c5b600881901c15610b5a5760049190911b9060081c5b600481901c15610b6f5760029190911b9060041c5b600281901c15610b8157600182901b91505b6001828581610b9257610b92610e54565b048301901c91506001828581610baa57610baa610e54565b048301901c91506001828581610bc257610bc2610e54565b048301901c91506001828581610bda57610bda610e54565b048301901c91506001828581610bf257610bf2610e54565b048301901c91506001828581610c0a57610c0a610e54565b048301901c91506001828581610c2257610c22610e54565b048301901c9150610c4282838681610c3c57610c3c610e54565b04610ac7565b949350505050565b476003556002546040516370a0823160e01b81523060048201526001600160a01b03909116906370a082319060240160206040518083038186803b158015610c9157600080fd5b505afa158015610ca5573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610cc99190610e06565b600455565b6000546001600160a01b0316331461075c5760405162461bcd60e51b815260206004820181905260248201527f4f776e61626c653a2063616c6c6572206973206e6f7420746865206f776e657260448201526064016103d0565b600080546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b6001600160a01b0381168114610a5157600080fd5b60008060408385031215610da057600080fd5b823591506020830135610db281610d78565b809150509250929050565b600060208284031215610dcf57600080fd5b8135610ad881610d78565b60008060408385031215610ded57600080fd5b8235610df881610d78565b946020939093013593505050565b600060208284031215610e1857600080fd5b5051919050565b634e487b7160e01b600052601160045260246000fd5b6000816000190483118215151615610e4f57610e4f610e1f565b500290565b634e487b7160e01b600052601260045260246000fd5b600082610e8757634e487b7160e01b600052601260045260246000fd5b500490565b600060208284031215610e9e57600080fd5b81518015158114610ad857600080fd5b60008219821115610ec157610ec1610e1f565b500190565b600082821015610ed857610ed8610e1f565b50039056fea2646970667358221220122299bee54ba80528f433cf830ff6bbdf179adbf5113ae5f9a4256d472d35b264736f6c63430008080033"
        
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
        

    
    End Class    
    
    Public Partial Class DepositfundsFunction
        Inherits DepositfundsFunctionBase
    End Class

        <[Function]("depositfunds")>
    Public Class DepositfundsFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("uint256", "_spcAmount", 1)>
        Public Overridable Property [SpcAmount] As BigInteger
        <[Parameter]("address", "_account", 2)>
        Public Overridable Property [Account] As String
    
    End Class
    
    
    Public Partial Class GetReservesFunction
        Inherits GetReservesFunctionBase
    End Class

        <[Function]("getReserves", GetType(GetReservesOutputDTO))>
    Public Class GetReservesFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class LptokenFunction
        Inherits LptokenFunctionBase
    End Class

        <[Function]("lptoken", "address")>
    Public Class LptokenFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class OwnerFunction
        Inherits OwnerFunctionBase
    End Class

        <[Function]("owner", "address")>
    Public Class OwnerFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class RenounceOwnershipFunction
        Inherits RenounceOwnershipFunctionBase
    End Class

        <[Function]("renounceOwnership")>
    Public Class RenounceOwnershipFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class SetLPTokenAddressFunction
        Inherits SetLPTokenAddressFunctionBase
    End Class

        <[Function]("setLPTokenAddress")>
    Public Class SetLPTokenAddressFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "_lptoken", 1)>
        Public Overridable Property [Lptoken] As String
    
    End Class
    
    
    Public Partial Class SetSpCoinAddressFunction
        Inherits SetSpCoinAddressFunctionBase
    End Class

        <[Function]("setSpCoinAddress")>
    Public Class SetSpCoinAddressFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "_spaceCoin", 1)>
        Public Overridable Property [SpaceCoin] As String
    
    End Class
    
    
    Public Partial Class SpaceCoinFunction
        Inherits SpaceCoinFunctionBase
    End Class

        <[Function]("spaceCoin", "address")>
    Public Class SpaceCoinFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class SwapFunction
        Inherits SwapFunctionBase
    End Class

        <[Function]("swap")>
    Public Class SwapFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "_account", 1)>
        Public Overridable Property [Account] As String
        <[Parameter]("uint256", "_spcAmount", 2)>
        Public Overridable Property [SpcAmount] As BigInteger
    
    End Class
    
    
    Public Partial Class TransferOwnershipFunction
        Inherits TransferOwnershipFunctionBase
    End Class

        <[Function]("transferOwnership")>
    Public Class TransferOwnershipFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "newOwner", 1)>
        Public Overridable Property [NewOwner] As String
    
    End Class
    
    
    Public Partial Class WithdrawfundsFunction
        Inherits WithdrawfundsFunctionBase
    End Class

        <[Function]("withdrawfunds")>
    Public Class WithdrawfundsFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "_account", 1)>
        Public Overridable Property [Account] As String
    
    End Class
    
    
    Public Partial Class AddliquidityEventDTO
        Inherits AddliquidityEventDTOBase
    End Class

    <[Event]("Addliquidity")>
    Public Class AddliquidityEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "_acoount", 1, true)>
        Public Overridable Property [Acoount] As String
    
    End Class    
    
    Public Partial Class OwnershipTransferredEventDTO
        Inherits OwnershipTransferredEventDTOBase
    End Class

    <[Event]("OwnershipTransferred")>
    Public Class OwnershipTransferredEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "previousOwner", 1, true)>
        Public Overridable Property [PreviousOwner] As String
        <[Parameter]("address", "newOwner", 2, true)>
        Public Overridable Property [NewOwner] As String
    
    End Class    
    
    Public Partial Class RemoveliquidityEventDTO
        Inherits RemoveliquidityEventDTOBase
    End Class

    <[Event]("Removeliquidity")>
    Public Class RemoveliquidityEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "_account", 1, true)>
        Public Overridable Property [Account] As String
    
    End Class    
    
    Public Partial Class TokenTradeEventDTO
        Inherits TokenTradeEventDTOBase
    End Class

    <[Event]("TokenTrade")>
    Public Class TokenTradeEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "_account", 1, true)>
        Public Overridable Property [Account] As String
        <[Parameter]("uint256", "_tradeEther", 2, false)>
        Public Overridable Property [TradeEther] As BigInteger
        <[Parameter]("uint256", "_tradeSpCoin", 3, false)>
        Public Overridable Property [TradeSpCoin] As BigInteger
    
    End Class    
    
    
    
    Public Partial Class GetReservesOutputDTO
        Inherits GetReservesOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class GetReservesOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("uint256", "", 1)>
        Public Overridable Property [ReturnValue1] As BigInteger
        <[Parameter]("uint256", "", 2)>
        Public Overridable Property [ReturnValue2] As BigInteger
    
    End Class    
    
    Public Partial Class LptokenOutputDTO
        Inherits LptokenOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class LptokenOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class OwnerOutputDTO
        Inherits OwnerOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class OwnerOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    
    
    
    
    
    
    Public Partial Class SpaceCoinOutputDTO
        Inherits SpaceCoinOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class SpaceCoinOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    
    
    
    

End Namespace
