using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projetoCRUD.Models;
using projetoCRUD.DAO;

namespace projetoCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Despesa des = new Despesa();
                DespesaDAO adao = new DespesaDAO();

                int escolha = 0;

                do
                {
                    Console.WriteLine("Escolha o que deseja realizar:");
                    Console.Write("\n[1] Inserir Despesa \n[2] Atualizar Despesa \n[3] Deletar Despesa \n[4] Listar Despesa \n[0] Sair \n\n>> ");
                    escolha = Convert.ToInt32(Console.ReadLine()); 

                    Console.Clear();

                    switch (escolha)
                    {
                        // CADASTRAR DESPESAS
                        case 1:
                            Console.WriteLine("- - - - - Cadastrar Despesa - - - - -");
                            Console.Write("\n-- Valor da Despesa:\n>> ");
                            des.valorDespesa = Convert.ToDouble(Console.ReadLine());
                            Console.Write("\n-- Data de Vencimento:\n>> ");
                            des.dataVenc = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("\n-- Data de Pagamento:\n>> ");
                            des.dataPag = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("\n-- Status da Despesa:\n>> ");
                            des.status = Console.ReadLine();

                            Console.WriteLine("\n-----------------------------------");
                            Console.WriteLine("Lista de todos os CAIXAS");

                            foreach (Caixa a in adao.ListaCaixa())
                            {
                                Console.Write("ID: [" + a.IdCai);
                                Console.Write("] - " + a.NomeFun + "\n");
                            }

                            Console.Write("\n-- Escolha o caixa que foi realizado a DESPESA:\n>> ");
                            des.idCaixaFK = Convert.ToInt32(Console.ReadLine());
                            adao.Insert(des);
                            break;

                        // ATUALIZAR DESPESAS
                        case 2:
                            Console.WriteLine("- - - - - Atualizar Despesa - - - - -\n");

                            // DEMONSTRAR AS DESPESAS CADASTRADAS
                            foreach (Despesa viewD in adao.List())
                            {
                                Console.WriteLine("ID: ["+viewD.idDespesa+"]  |  VALOR: "+viewD.valorDespesa+"  |  VENCIMENTO: "+viewD.dataVenc);
                            }

                            Console.Write("\n--> Escolha do ID da Despesa para alterar:\n>> ");
                            int idEsc = Convert.ToInt32(Console.ReadLine());

                            //REALIZAR A ATUALIZAÇÃO E O VALOR ANTERIOR
                            foreach (Despesa despAtu in adao.List())
                            {
                                if(idEsc == despAtu.idDespesa)
                                {
                                    des.idDespesa = despAtu.idDespesa;
                                    Console.Write("\n-- Valor da despesa: \nDE: " + despAtu.valorDespesa + "\nPARA: ");
                                    des.valorDespesa = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("\n-- Data do vencimento: \nDE: " + despAtu.dataVenc + "\nPARA: ");
                                    des.dataVenc = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("\n-- Data de pagamento: \nDE: " + despAtu.dataPag+ "\nPARA: ");
                                    des.dataPag = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("\n-- Status da despesa: \nDE: " + despAtu.status + "\nPARA: ");
                                    des.status = Console.ReadLine();

                                    Console.WriteLine("\n-----------------------------------");
                                    Console.WriteLine("Lista de todos os CAIXAS");

                                    foreach (Caixa a in adao.ListaCaixa())
                                    {
                                        Console.Write("ID: [" + a.IdCai);
                                        Console.Write("] - " + a.NomeFun + "\n");
                                    }
                                    Console.Write("\n-- Id do Caixa da despesa: \nE: " + despAtu.idCaixaFK + "\nPARA: ");
                                    des.idCaixaFK = Convert.ToInt32(Console.ReadLine());
                                    
                                    adao.Update(des);
                                }
                            }

                            break;

                        // DELETAR O REGISTRO DE DESPESA
                        case 3:
                            Console.WriteLine("- - - - - Deletar Despesa - - - - -\n");
                            // LISTA TODAS AS DESPESAS
                            foreach (Despesa viewD in adao.List())
                            {
                                Console.WriteLine("ID: [" + viewD.idDespesa + "]  |  VALOR: " + viewD.valorDespesa + "  |  VENCIMENTO: " + viewD.dataVenc);
                            }
                            Console.Write("\n-- Selecione o ID da despesa que deseja DELETAR:\n>> ");
                            des.idDespesa = Convert.ToInt32(Console.ReadLine());
                            adao.Delete(des);
                            break;
                        
                        // LISTAR TODAS AS DESPESAS
                        case 4:
                            Console.WriteLine("- - - - - - - LISTA DE DESPESAS - - - - - - -");
                            foreach (Despesa d in adao.List())
                            {
                                Console.WriteLine("\n-- ID: "+ d.idDespesa);
                                Console.WriteLine("-- Valor da Despesa: "+ d.valorDespesa);
                                Console.WriteLine("-- Data de Vencimento: "+ d.dataVenc);
                                Console.WriteLine("-- Data de Pagamento: "+ d.dataPag);
                                Console.WriteLine("-- Status: "+ d.status);
                                Console.WriteLine("-- ID do Caixa da Despesa: "+ d.idCaixaFK);
                            }
                            break;
                    }

                    // SELEÇÃO PARA FINALIZAR A APLICAÇÃO
                    Console.WriteLine("\n-- Deseja sair da aplicação?");
                    Console.Write("[0] Sim\n[1] Não\n>> ");
                    escolha = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                } while (escolha != 0);
            }
            catch (Exception ex)
            {
               Console.WriteLine($"\n Erro {ex.Message}");
            }
        }
    }
}
