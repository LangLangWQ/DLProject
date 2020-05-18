
public interface IResourcesLoadingMode {

    void ResourcesLoading<T>(T t, string path, bool IsAsync) where T : UnityEngine.Object;
    void ResourcesLoading<T>(T t) where T : UnityEngine.Object;
}
