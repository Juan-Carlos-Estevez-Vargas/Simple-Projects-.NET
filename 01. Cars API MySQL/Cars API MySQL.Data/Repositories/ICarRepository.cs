using Cars_API_MySQL.Model;

namespace Cars_API_MySQL.Data.Repositories
{
    public interface ICarRepository
    {
        /// <summary>
        /// Obtiene todos los carros.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. La tarea devuelve un objeto IEnumerable de tipo Car que representa la lista de carros.
        /// </returns>
        Task<IEnumerable<Car>> GetAllCars();

        /// <summary>
        /// Obtiene los detalles de un carro específico por su ID.
        /// </summary>
        /// <param name="id">ID del carro.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. La tarea devuelve un objeto Car que representa los detalles del carro.
        /// </returns>
        Task<Car> GetDetails(int id);

        /// <summary>
        /// Inserta un nuevo carro en el repositorio.
        /// </summary>
        /// <param name="car">Objeto Car que representa el carro a insertar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. La tarea devuelve un valor booleano que indica si la inserción fue exitosa o no.
        /// </returns>
        Task<bool> InsertCar(Car car);

        /// <summary>
        /// Actualiza un carro existente en el repositorio.
        /// </summary>
        /// <param name="car">Objeto Car que representa el carro actualizado.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. La tarea devuelve un valor booleano que indica si la actualización fue exitosa o no.
        /// </returns>
        Task<bool> UpdateCar(Car car);

        /// <summary>
        /// Elimina un carro existente del repositorio.
        /// </summary>
        /// <param name="car">Objeto Car que representa el carro a eliminar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. La tarea devuelve un valor booleano que indica si la eliminación fue exitosa o no.
        /// </returns>
        Task<bool> DeleteCar(Car car);
    }
}
