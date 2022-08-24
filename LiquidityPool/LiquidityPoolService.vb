Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts.ContractHandlers
Imports Nethereum.Contracts
Imports System.Threading
Imports DEFIex.Contracts.LiquidityPool.ContractDefinition
Namespace DEFIex.Contracts.LiquidityPool


    Public Partial Class LiquidityPoolService
    
    
        Public Shared Function DeployContractAndWaitForReceiptAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal liquidityPoolDeployment As LiquidityPoolDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return web3.Eth.GetContractDeploymentHandler(Of LiquidityPoolDeployment)().SendRequestAndWaitForReceiptAsync(liquidityPoolDeployment, cancellationTokenSource)
        
        End Function
         Public Shared Function DeployContractAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal liquidityPoolDeployment As LiquidityPoolDeployment) As Task(Of String)
        
            Return web3.Eth.GetContractDeploymentHandler(Of LiquidityPoolDeployment)().SendRequestAsync(liquidityPoolDeployment)
        
        End Function
        Public Shared Async Function DeployContractAndGetServiceAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal liquidityPoolDeployment As LiquidityPoolDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of LiquidityPoolService)
        
            Dim receipt = Await DeployContractAndWaitForReceiptAsync(web3, liquidityPoolDeployment, cancellationTokenSource)
            Return New LiquidityPoolService(web3, receipt.ContractAddress)
        
        End Function
    
        Protected Property Web3 As Nethereum.Web3.Web3
        
        Public Property ContractHandler As ContractHandler
        
        Public Sub New(ByVal web3 As Nethereum.Web3.Web3, ByVal contractAddress As String)
            Web3 = web3
            ContractHandler = web3.Eth.GetContractHandler(contractAddress)
        End Sub
    
        Public Function DepositfundsRequestAsync(ByVal depositfundsFunction As DepositfundsFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of DepositfundsFunction)(depositfundsFunction)
        
        End Function

        Public Function DepositfundsRequestAndWaitForReceiptAsync(ByVal depositfundsFunction As DepositfundsFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of DepositfundsFunction)(depositfundsFunction, cancellationToken)
        
        End Function

        
        Public Function DepositfundsRequestAsync(ByVal [spcAmount] As BigInteger, ByVal [account] As String) As Task(Of String)
        
            Dim depositfundsFunction = New DepositfundsFunction()
                depositfundsFunction.SpcAmount = [spcAmount]
                depositfundsFunction.Account = [account]
            
            Return ContractHandler.SendRequestAsync(Of DepositfundsFunction)(depositfundsFunction)
        
        End Function

        
        Public Function DepositfundsRequestAndWaitForReceiptAsync(ByVal [spcAmount] As BigInteger, ByVal [account] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim depositfundsFunction = New DepositfundsFunction()
                depositfundsFunction.SpcAmount = [spcAmount]
                depositfundsFunction.Account = [account]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of DepositfundsFunction)(depositfundsFunction, cancellationToken)
        
        End Function
        Public Function GetReservesQueryAsync(ByVal getReservesFunction As GetReservesFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetReservesOutputDTO)
        
            Return ContractHandler.QueryDeserializingToObjectAsync(Of GetReservesFunction, GetReservesOutputDTO)(getReservesFunction, blockParameter)
        
        End Function

        
        Public Function GetReservesQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of GetReservesOutputDTO)
        
            return ContractHandler.QueryDeserializingToObjectAsync(Of GetReservesFunction, GetReservesOutputDTO)(Nothing, blockParameter)
        
        End Function



        Public Function LptokenQueryAsync(ByVal lptokenFunction As LptokenFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of LptokenFunction, String)(lptokenFunction, blockParameter)
        
        End Function

        
        Public Function LptokenQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of LptokenFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function OwnerQueryAsync(ByVal ownerFunction As OwnerFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of OwnerFunction, String)(ownerFunction, blockParameter)
        
        End Function

        
        Public Function OwnerQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of OwnerFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function RenounceOwnershipRequestAsync(ByVal renounceOwnershipFunction As RenounceOwnershipFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of RenounceOwnershipFunction)(renounceOwnershipFunction)
        
        End Function

        Public Function RenounceOwnershipRequestAsync() As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of RenounceOwnershipFunction)
        
        End Function

        Public Function RenounceOwnershipRequestAndWaitForReceiptAsync(ByVal renounceOwnershipFunction As RenounceOwnershipFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of RenounceOwnershipFunction)(renounceOwnershipFunction, cancellationToken)
        
        End Function

        Public Function RenounceOwnershipRequestAndWaitForReceiptAsync(ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of RenounceOwnershipFunction)(Nothing, cancellationToken)
        
        End Function
        Public Function SetLPTokenAddressRequestAsync(ByVal setLPTokenAddressFunction As SetLPTokenAddressFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SetLPTokenAddressFunction)(setLPTokenAddressFunction)
        
        End Function

        Public Function SetLPTokenAddressRequestAndWaitForReceiptAsync(ByVal setLPTokenAddressFunction As SetLPTokenAddressFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetLPTokenAddressFunction)(setLPTokenAddressFunction, cancellationToken)
        
        End Function

        
        Public Function SetLPTokenAddressRequestAsync(ByVal [lptoken] As String) As Task(Of String)
        
            Dim setLPTokenAddressFunction = New SetLPTokenAddressFunction()
                setLPTokenAddressFunction.Lptoken = [lptoken]
            
            Return ContractHandler.SendRequestAsync(Of SetLPTokenAddressFunction)(setLPTokenAddressFunction)
        
        End Function

        
        Public Function SetLPTokenAddressRequestAndWaitForReceiptAsync(ByVal [lptoken] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim setLPTokenAddressFunction = New SetLPTokenAddressFunction()
                setLPTokenAddressFunction.Lptoken = [lptoken]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetLPTokenAddressFunction)(setLPTokenAddressFunction, cancellationToken)
        
        End Function
        Public Function SetSpCoinAddressRequestAsync(ByVal setSpCoinAddressFunction As SetSpCoinAddressFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SetSpCoinAddressFunction)(setSpCoinAddressFunction)
        
        End Function

        Public Function SetSpCoinAddressRequestAndWaitForReceiptAsync(ByVal setSpCoinAddressFunction As SetSpCoinAddressFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetSpCoinAddressFunction)(setSpCoinAddressFunction, cancellationToken)
        
        End Function

        
        Public Function SetSpCoinAddressRequestAsync(ByVal [spaceCoin] As String) As Task(Of String)
        
            Dim setSpCoinAddressFunction = New SetSpCoinAddressFunction()
                setSpCoinAddressFunction.SpaceCoin = [spaceCoin]
            
            Return ContractHandler.SendRequestAsync(Of SetSpCoinAddressFunction)(setSpCoinAddressFunction)
        
        End Function

        
        Public Function SetSpCoinAddressRequestAndWaitForReceiptAsync(ByVal [spaceCoin] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim setSpCoinAddressFunction = New SetSpCoinAddressFunction()
                setSpCoinAddressFunction.SpaceCoin = [spaceCoin]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SetSpCoinAddressFunction)(setSpCoinAddressFunction, cancellationToken)
        
        End Function
        Public Function SpaceCoinQueryAsync(ByVal spaceCoinFunction As SpaceCoinFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of SpaceCoinFunction, String)(spaceCoinFunction, blockParameter)
        
        End Function

        
        Public Function SpaceCoinQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of SpaceCoinFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function SwapRequestAsync(ByVal swapFunction As SwapFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of SwapFunction)(swapFunction)
        
        End Function

        Public Function SwapRequestAndWaitForReceiptAsync(ByVal swapFunction As SwapFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SwapFunction)(swapFunction, cancellationToken)
        
        End Function

        
        Public Function SwapRequestAsync(ByVal [account] As String, ByVal [spcAmount] As BigInteger) As Task(Of String)
        
            Dim swapFunction = New SwapFunction()
                swapFunction.Account = [account]
                swapFunction.SpcAmount = [spcAmount]
            
            Return ContractHandler.SendRequestAsync(Of SwapFunction)(swapFunction)
        
        End Function

        
        Public Function SwapRequestAndWaitForReceiptAsync(ByVal [account] As String, ByVal [spcAmount] As BigInteger, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim swapFunction = New SwapFunction()
                swapFunction.Account = [account]
                swapFunction.SpcAmount = [spcAmount]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of SwapFunction)(swapFunction, cancellationToken)
        
        End Function
        Public Function TransferOwnershipRequestAsync(ByVal transferOwnershipFunction As TransferOwnershipFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of TransferOwnershipFunction)(transferOwnershipFunction)
        
        End Function

        Public Function TransferOwnershipRequestAndWaitForReceiptAsync(ByVal transferOwnershipFunction As TransferOwnershipFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of TransferOwnershipFunction)(transferOwnershipFunction, cancellationToken)
        
        End Function

        
        Public Function TransferOwnershipRequestAsync(ByVal [newOwner] As String) As Task(Of String)
        
            Dim transferOwnershipFunction = New TransferOwnershipFunction()
                transferOwnershipFunction.NewOwner = [newOwner]
            
            Return ContractHandler.SendRequestAsync(Of TransferOwnershipFunction)(transferOwnershipFunction)
        
        End Function

        
        Public Function TransferOwnershipRequestAndWaitForReceiptAsync(ByVal [newOwner] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim transferOwnershipFunction = New TransferOwnershipFunction()
                transferOwnershipFunction.NewOwner = [newOwner]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of TransferOwnershipFunction)(transferOwnershipFunction, cancellationToken)
        
        End Function
        Public Function WithdrawfundsRequestAsync(ByVal withdrawfundsFunction As WithdrawfundsFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of WithdrawfundsFunction)(withdrawfundsFunction)
        
        End Function

        Public Function WithdrawfundsRequestAndWaitForReceiptAsync(ByVal withdrawfundsFunction As WithdrawfundsFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of WithdrawfundsFunction)(withdrawfundsFunction, cancellationToken)
        
        End Function

        
        Public Function WithdrawfundsRequestAsync(ByVal [account] As String) As Task(Of String)
        
            Dim withdrawfundsFunction = New WithdrawfundsFunction()
                withdrawfundsFunction.Account = [account]
            
            Return ContractHandler.SendRequestAsync(Of WithdrawfundsFunction)(withdrawfundsFunction)
        
        End Function

        
        Public Function WithdrawfundsRequestAndWaitForReceiptAsync(ByVal [account] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim withdrawfundsFunction = New WithdrawfundsFunction()
                withdrawfundsFunction.Account = [account]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of WithdrawfundsFunction)(withdrawfundsFunction, cancellationToken)
        
        End Function
    
    End Class

End Namespace
