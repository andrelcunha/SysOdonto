using System;
using System.Data;
using Npgsql;


namespace SysOdonto1
{
	public class Paciente
	{
		/*
		
*/


		public Paciente()
		{
			/*codigo = 0;
			nome = string.Empty;
			dataNasc = 0;
			logradouro = string.Empty;
			num = 0;
			complm = string.Empty;
  			bairro = string.Empty;
  			cidade = string.Empty;
			id_estado = 0;
			cep = 0;
			fone = 0;
			ativo = false;*/
		}

		public void Insert(string[] values)
		{
			string sQuery = string.Empty;
			sQuery = string.Format("INSERT INTO public.tb_paciente(codigo," +
			                       " nome, data_nasc," +
			                       " logradouro, num_end," +
			                       " complm_end, bairro," +
			                       " cidade, estado, cep, fone,ativo)" +
			                       " VALUES ({0},{1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11});"
			                       ,values[0],values[1],values[2]
			                       ,values[3],values[4],values[5],values[6],values[7]
			                       ,values[8],values[9],values[10],values[11]);
			/*
			this.nome = nome;
				this.dataNasc = dataNasc;
				this.logradouro=logradouro;
				this.num = num;
				this.complm = complm;
				this.bairro = bairro;
				this.cidade = cidade;
				this.estado_id = estado_id;
				this.cep = cep;
				this.fone = fone;
	            this.ativo = ativo;
				*/
			var conn = new dbconnect.dbConnect_pg(sQuery);


				
		}
		public void Delete()
		{

		}
		public void Update()
		{

		}

		public string Searchbyname(string nome)
		{
			var sQuery = string.Format("SELECT * FROM tb_paciente" +
			                              " WHERE nome = '{0}';",nome);
			var conn = new dbconnect.dbConnect_pg(sQuery);
			var Table = conn.get_table();
			string sRow=string.Empty;
			if(Table.Rows.Count != 0)
				foreach (var item in Table.Rows[0].ItemArray) 
				{
					sRow += item;
					sRow += " ";
				}
			return sRow;
		}
        public DataTable Searchbyname_dt(string nome)
        {
            var sQuery = string.Format("SELECT * FROM tb_paciente" +
                                          " WHERE nome = '{0}';", nome);
            var conn = new dbconnect.dbConnect_pg(sQuery);
            var Table = conn.get_table(); 
            return Table;
        }
        public string Searchbycodigo(int codigo)
		{
			var sQuery = string.Format("SELECT * FROM tb_paciente" +
										  " WHERE codigo = '{0}';", codigo);
			var conn = new dbconnect.dbConnect_pg(sQuery);
			var Table = conn.get_table();
			string sRow=string.Empty;
			if(Table.Rows.Count != 0)
				foreach (var item in Table.Rows[0].ItemArray)
				{
					sRow += item;
					sRow += " ";
				}
			return sRow;
		}

        public DataTable Searchbycodigo_dt(int codigo)
        {
            var sQuery = string.Format("SELECT * FROM tb_paciente" +
                                          " WHERE codigo = '{0}';", codigo);
            var conn = new dbconnect.dbConnect_pg(sQuery);
            var Table = conn.get_table();
            
            return Table;
        }
        public bool existeCodigo(int codigo)
		{
            var sQuery = string.Format("SELECT COUNT(codigo) FROM tb_paciente" +
                                          " WHERE codigo = '{0}';", codigo);
            var conn = new dbconnect.dbConnect_pg(sQuery);
            var Table = conn.get_table();
            string result = string.Empty;
            if (Table.Rows.Count != 0)
                result = Table.Rows[0][0].ToString();      
            bool flagExiste = !(result.Equals(string.Empty));
            return flagExiste;
        }
        public int proximoCodigo()
		{
			int codigo=0;
			var sQuery = "SELECT MAX(codigo) FROM public.tb_paciente;";
			var conn = new dbconnect.dbConnect_pg(sQuery);
			var Table = conn.get_table();
			if ((Table.Rows.GetType()).Equals(DBNull.Value))
				codigo = Convert.ToInt32(Table.Rows[0].ItemArray[0]);
			return ++codigo;
		}
	}
}
