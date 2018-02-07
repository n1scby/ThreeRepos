using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace Infrastructure
{
    public class ResortRepositoryADO : IResortRepository
    {
        private string connectString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-ThreeRepos-320AB4C4-D381-4AE0-8E23-5D0061B8F691;Trusted_Connection=True;MultipleActiveResultSets=true";
        private string selectQuery = "SELECT Id, Name, Location, Image FROM Resort \n";
        private string byId = "WHERE Id = @id";
        private string deleteQuery = "DELETE Resort \n";
        private string updateQuery = "UPDATE Resort SET Name = @name, Location = @location, Image = @image \n";
        private string insertQuery = "INSERT into Resort (Name, Location, Image) values(@name, @location, @image)";



        public void Add(Resort newResort)
        {
            using(SqlConnection conn = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", newResort.Name);
                cmd.Parameters.AddWithValue("@location", newResort.Location);
                cmd.Parameters.AddWithValue("@image", newResort.Image ?? "");  //if null pass empty string

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            } 
        }

        public void Delete(Resort deleteResort)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand(deleteQuery + byId, conn);
                cmd.Parameters.AddWithValue("@id", deleteResort.Id);
               

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public void Edit(Resort updatedResort)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand(updateQuery + byId, conn);
                cmd.Parameters.AddWithValue("@name", updatedResort.Name);
                cmd.Parameters.AddWithValue("@location", updatedResort.Location);
                cmd.Parameters.AddWithValue("@image", updatedResort.Image);
                cmd.Parameters.AddWithValue("@id", updatedResort.Id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public Resort GetById(int id)
        {
            Resort getResort = new Resort();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery + byId, conn);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        getResort = new Resort
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Location = reader[2].ToString(),
                            Image = reader[3].ToString()
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

            }
            return getResort;

        }

        public List<Resort> GetList()
        {
            List<Resort> resortList = new List<Resort>();

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Resort getResort = new Resort
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Location = reader[2].ToString(),
                            Image = reader[3].ToString()
                        };

                        resortList.Add(getResort);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

            }
            return resortList;
        }
    }
}
