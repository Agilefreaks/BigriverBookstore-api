from abc import ABC, abstractmethod


class Repository(ABC):
    """ A repository is just another abstraction layer that sits between
    the business logic layer and the data access layer.
    Also, a repository shouldn't implement an update() or save()
    method as that is not its job.
    """

    @abstractmethod
    def get(self, id):
        pass

    @abstractmethod
    def get_all(self):
        pass
