using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace CgvCmsApi.Controls
{
	public class SqlHelper
	{
		#region member ---------------------------------------------------------------------------------------------------------------------------------------------
		public static readonly SqlHelper Instance;
		private readonly ILog log = LogManager.GetLogger(typeof(SqlHelper)); 
		#endregion

		#region property -------------------------------------------------------------------------------------------------------------------------------------------
		private string cnStr { get; set; }
		#endregion

		#region creator -------------------------------------------------------------------------------------------------------------------------------------------
		static SqlHelper()
		{
			Instance = new SqlHelper();
		}
		private SqlHelper()
		{
			this.cnStr = WebConfigurationManager.ConnectionStrings["cgv"].ConnectionString;
		}
		#endregion

		#region public method -------------------------------------------------------------------------------------------------------------------------------------

		public int ExecuteNonQuery(string procName, List<SqlParameter> para = null)
		{
			int ret = 0;
			SqlConnection cn = this.GetConnection();
			SqlCommand cm = new SqlCommand(procName, cn);

			cm.CommandType = System.Data.CommandType.StoredProcedure;
			if (para != null)
				cm.Parameters.AddRange(para.ToArray());

			try
			{
				cn.Open();
				ret = cm.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				ret = 0;
			}
			finally
			{
				cm.Dispose();
				cn.Close();
				cn.Dispose();
			}
			return ret;
		}

		public SqlResult ExecuteReader(string procName, List<SqlParameter> para = null)
		{
			SqlResult ret = new SqlResult();
			ret.Cn = this.GetConnection();
			ret.Cm = new SqlCommand(procName, ret.Cn);
			ret.Cm.CommandType = System.Data.CommandType.StoredProcedure;
			if (para != null)
				ret.Cm.Parameters.AddRange(para.ToArray());
			try
			{
				ret.Cn.Open();
				ret.Dr = ret.Cm.ExecuteReader();
			}
			catch (Exception ex)
			{
				ret.ClearResource();
				ret = null;
			}
			return ret;
		}

		public List<T> GetListFromDataReader<T>(SqlDataReader dr) where T : new()
		{
			List<T> ret = new List<T>();

			try
			{
				List<string> cols = new List<string>();
				for (int i = 0; i < dr.FieldCount; ++i)
					cols.Add(dr.GetName(i));
				object val = null;
				while (dr.Read())
				{
					var item = new T();
					Type t = item.GetType();
					foreach (PropertyInfo prop in t.GetProperties())
					{
						if (cols.Contains(prop.Name) && dr[prop.Name] != DBNull.Value)
						{
							Type type = prop.PropertyType;
							type = Nullable.GetUnderlyingType(type) ?? type;
							val = dr[prop.Name];
							prop.SetValue(item, Convert.ChangeType(val, type), null);
						}
					}
					ret.Add(item);
				}
			}
			catch (Exception ex)
			{
				ret = null;
			}
			return ret;
		}

		public List<T> ExecuteList<T>(string procName, List<SqlParameter> para = null, CommandType cmdType = CommandType.StoredProcedure) where T : new()
		{
			SqlConnection cn = this.GetConnection();
			SqlCommand cm = new SqlCommand(procName, cn);
			cm.CommandType = cmdType;
			if (para != null)
				cm.Parameters.AddRange(para.ToArray());


			List<T> ret = new List<T>();
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader();

				List<string> cols = new List<string>();
				for (int i = 0; i < dr.FieldCount; ++i)
					cols.Add(dr.GetName(i));
				object val = null;
				while (dr.Read())
				{
					var item = new T();
					Type t = item.GetType();
					foreach (PropertyInfo prop in t.GetProperties())
					{
						if (cols.Contains(prop.Name) && dr[prop.Name] != DBNull.Value)
						{
							Type type = prop.PropertyType;
							type = Nullable.GetUnderlyingType(type) ?? type;
							val = dr[prop.Name];
							prop.SetValue(item, Convert.ChangeType(val, type), null);
						}
					}
					ret.Add(item);
				}
			}
			catch (Exception ex)
			{
				log.ErrorFormat("{0}", ex.Message);
				ret = null;
			}
			finally
			{
				cm.Dispose();
				cn.Close();
				cn.Dispose();
			}
			return ret;
		}

		public List<T> ExecutePageList<T>(string procName, int curPage, int pageNum, List<SqlParameter> para = null) where T : new()
		{
			SqlConnection cn = this.GetConnection();
			SqlCommand cm = new SqlCommand(procName, cn);
			cm.CommandType = System.Data.CommandType.StoredProcedure;
			if (para != null)
				cm.Parameters.AddRange(para.ToArray());


			List<T> ret = new List<T>();
			try
			{
				cn.Open();
				SqlDataReader dr = cm.ExecuteReader();

				List<string> cols = new List<string>();
				for (int i = 0; i < dr.FieldCount; ++i)
					cols.Add(dr.GetName(i));
				object val = null;
				int cnt = 0;
				while (dr.Read())
				{

					if (cnt >= (curPage - 1) * pageNum && cnt < curPage * pageNum)
					{
						var item = new T();
						Type t = item.GetType();
						foreach (PropertyInfo prop in t.GetProperties())
						{
							if (cols.Contains(prop.Name) && dr[prop.Name] != DBNull.Value)
							{
								Type type = prop.PropertyType;
								type = Nullable.GetUnderlyingType(type) ?? type;
								val = dr[prop.Name];
								prop.SetValue(item, Convert.ChangeType(val, type), null);
							}
						}
						ret.Add(item);
					}
					cnt++;
				}
			}
			catch (Exception ex)
			{
				ret = null;
			}
			finally
			{
				cm.Dispose();
				cn.Close();
				cn.Dispose();
			}
			return ret;
		}

		#endregion

		#region override method -----------------------------------------------------------------------------------------------------------------------------------
		#endregion

		#region event handler -------------------------------------------------------------------------------------------------------------------------------------

		#endregion

		#region private method ------------------------------------------------------------------------------------------------------------------------------------
		private void InitControls()
		{

		}

		private SqlConnection GetConnection()
		{
			SqlConnection cn = new SqlConnection();
			cn.ConnectionString = this.cnStr;
			return cn;
		}
		#endregion
	}

	public class SqlResult
	{
		public SqlConnection Cn { get; set; }
		public SqlCommand Cm { get; set; }
		public SqlDataReader Dr { get; set; }


		public void ClearResource()
		{
			if (this.Dr != null)
			{
				try { this.Dr.Close(); } catch { }

			}

			if (this.Cm != null)
			{
				try { this.Cm.Dispose(); } catch { }
			}

			if (this.Cn != null)
			{
				try
				{
					this.Cn.Close();
					this.Cn.Dispose();
				}
				catch { }
			}

		}
	}
}